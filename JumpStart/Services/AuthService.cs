using JumpStart.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart.Services;
public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly ProtectedSessionStorage _storage;

    private readonly IMemoryCache _cache;

    public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtConfiguration jwtConfiguration, IMemoryCache cache)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtConfiguration = jwtConfiguration;
        _cache = cache;
    }
    public async Task<SignInResult> AuthenticateUser(string username, string password, bool rememberMe, bool lockoutOnFailure = false)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure);

        if (result.Succeeded)
        {
            // populate user information and save to the cache
            var user = await GetIdentityUser(username);
            UserInfo userInfo = new UserInfo()
            {
                Id = user.Id,
                Username = user.UserName,
                BearerToken = GetBearerToken(user)
            };

            if (user != null)
            {
                _cache.Set(user.Id, userInfo);
            }

        }
        return result;
    }

    public string GetBearerToken(IdentityUser user)
    {
        var credentials = new SigningCredentials(_jwtConfiguration.SecurityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
        };

        var token = new JwtSecurityToken(
            issuer: _jwtConfiguration.TokenIssuer,
            audience: _jwtConfiguration.TokenAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1), // Token expiration time
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    public async Task<IdentityUser> GetIdentityUser(string username)
    {
        var user = await _userManager.FindByEmailAsync(username);
        return user;
    }
}
