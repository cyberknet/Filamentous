
using Microsoft.AspNetCore.Identity;

namespace JumpStart.Services;

public interface IAuthService
{
    Task<SignInResult> AuthenticateUser(string username, string password, bool rememberMe, bool lockoutOnFailure = false);
    string GetBearerToken(IdentityUser user);
    Task<IdentityUser> GetIdentityUser(string username);
}