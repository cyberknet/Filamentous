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
            .AddApplicationPart(typeof(AuthController).Assembly);

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

        return mvcBuilder;
    }


}


