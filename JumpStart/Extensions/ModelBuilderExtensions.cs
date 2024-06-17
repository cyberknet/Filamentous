using Filamentous.Web.Controllers.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JumpStart.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using JumpStart.Models;
using System.Security.Cryptography;
using JumpStart.Services;
using System.Security.AccessControl;
using System.Xml.Schema;
using System.Text.Json.Serialization;

namespace Microsoft.Extensions.DependencyInjection;
public static class JumpStartModelBuilderExtensions
{
    public static IMvcBuilder AddJumpStart(this IServiceCollection services, string tokenIssuer, string tokenAudience, string signingKey)
    {
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        byte[] salt = new byte[16];
        rng.GetBytes(salt);
        int keyLength = 32;
        using var pbkdf2 = new Rfc2898DeriveBytes(signingKey, salt, 10000, HashAlgorithmName.SHA256);
        var keyBytes = pbkdf2.GetBytes(keyLength);


        // Use the generated key for signing the JWT token
        var securityKey = new SymmetricSecurityKey(keyBytes);

        // Update the JwtConfiguration with the new signing key
        var jwtConfiguration = new JwtConfiguration
        {
            SigningKey = signingKey,
            TokenAudience = tokenAudience,
            TokenIssuer = tokenIssuer,
            SecurityKey = securityKey
        };

        var mvcBuilder = services
            .AddControllers()
            .AddApplicationPart(typeof(AuthController).Assembly)
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = tokenIssuer,
                ValidAudience = tokenAudience,
                IssuerSigningKey = jwtConfiguration.SecurityKey
            };
        });

        // Register the JwtConfiguration as a singleton service
        services.AddSingleton(jwtConfiguration);
        services.AddTransient<IAuthService, AuthService>();
        services.AddScoped<UserInfo>();

        // add an in-memory cache for AuthService
        services.AddMemoryCache();

        // add support for localization
        services.AddLocalization();//options => options.ResourcesPath = "Resources");

        // automatically add any services that inherit from DataService<TEntity> and have an interface that implements IDataService<TEntity>
        // note, the code takes into account inheritance, so the services do not need to directly inherit from DataService<TEntity> or directly implement IDataService<TEntity> 
        AddServiceDependencies(services);

        return mvcBuilder;
    }


    private static void AddServiceDependencies(IServiceCollection services)
    {
        // get the list of services we should add for dependency injection
        var dependencies = GetServiceDependencies();
        foreach(var (iface, service) in dependencies)
        {
            services.AddScoped(iface, service);
        }
    }


    private static Dictionary<Type, Type> GetServiceDependencies()
    {
        Dictionary<Type, Type> serviceDependencies = new ();
        
        // get the list of services we should add
        var services = GetServices();

        // Register services that implement interfaces inheriting from IDataService<TEntity>
        foreach (var serviceType in services)
        {
            var interfaces = serviceType.GetInterfaces().ToList();

            // get a list of the interfaces this class implements, along with the count of levels in the hierarchy until the interface implements IDataService<TEntity>
            var leveledInterfaces = interfaces
                .Select(i => new
                {
                    InterfaceType = i,
                    InheritanceLevels = CountInheritanceLevels(typeof(IDataService<>), i)
                }).ToList();
            // filter out any interfaces that have -1 levels (they do not implement IDataService<TEntity>)
            var filteredInterfaces = leveledInterfaces
                .Where(x => x.InheritanceLevels >= 0).ToList(); // Filter out interfaces that don't inherit from IDataService<TEntity>
            // order the list by the number of levels descending - the highest number of levels is the most specific interface
            var orderedInterfaces = filteredInterfaces
                .OrderByDescending(x => x.InheritanceLevels)
                .Select(x => x.InterfaceType)
                .ToList();
            // if any interfaces remain
            if (orderedInterfaces.Any())
            {
                // take the first interface (most specific)
                var iface = orderedInterfaces.First();
                // and add it as service dependency to be processed later
                serviceDependencies.Add(iface, serviceType);
            }
        }
        return serviceDependencies;
    }


    #region GetServices
    private static List<Type> GetServices()
    {
        var assemblies = GetReferencedAssemblies();

        var serviceList = assemblies.SelectMany(a => GetTypesSafely(a))
                                    .Where(t => t.IsClass && !t.IsAbstract && InheritsFromDataService(t))
                                    .ToList();
        return serviceList;
    }

    private static bool InheritsFromDataService(Type? type)
    {
        var baseType = typeof(DataService<>);

        // Traverse type's inheritance hierarchy
        while (type != null && type != typeof(object))
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == baseType)
            {
                return true;
            }
            type = type.BaseType;
        }

        return false;
    }

    private static HashSet<Assembly> GetReferencedAssemblies()
    {
        var assemblies = new HashSet<Assembly>();
        var stack = new Stack<Assembly>();
        var entryAssembly = Assembly.GetEntryAssembly();
        if (entryAssembly != null)
        {
            stack.Push(entryAssembly);

            while (stack.Count > 0)
            {
                var currentAssembly = stack.Pop();

                if (!assemblies.Add(currentAssembly))
                    continue;

                foreach (var reference in currentAssembly.GetReferencedAssemblies())
                {
                    try
                    {
                        var loadedAssembly = Assembly.Load(reference);
                        stack.Push(loadedAssembly);
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it) but continue processing other assemblies
                        Console.WriteLine($"Failed to load assembly: {reference.FullName}, Exception: {ex.Message}");
                    }
                }
            }
        }

        return assemblies;
    }

    private static Type[] GetTypesSafely(Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException e)
        {
            List<Type> types = new List<Type>();
            foreach (var type in e.Types)
                if (type != null)
                    types.Add(type);
            return types.ToArray();
        }
    }
    #endregion

    private static int CountInheritanceLevels(Type baseGenericType, Type interfaceType)
    {
        // check if the interface type is generic
        if (interfaceType.IsGenericType)
        {
            // get the generic type definition for the current interface
            var baseInterfaceType = interfaceType.GetGenericTypeDefinition();
            // if it matches the base generic type, return 0
            if (baseGenericType == baseInterfaceType) return 0;
        }

        // Traverse through the implemented interfaces of interfaceType
        var interfaces = interfaceType.GetInterfaces();

        foreach (var iface in interfaces)
        {
            int levels = CountInheritanceLevels(baseGenericType, iface);
            if (levels >= 0)
                return levels + 1; // Add 1 for the current level
        }

        // If baseGenericType was not found in the inheritance chain, return -1
        return -1;
    }
}


