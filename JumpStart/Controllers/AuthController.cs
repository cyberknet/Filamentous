using JumpStart.Models;
using JumpStart.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JumpStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var result = await _authService.AuthenticateUser(model.Username, model.Password, false, false);
        if (result.Succeeded)
        {
            var user = await _authService.GetIdentityUser(model.Username);
            string token = string.Empty;
            if (user != null)
            { 
                token = _authService.GetBearerToken(user);
            }
            return Ok(new { token });
        }
        else
        {
            return BadRequest("Invalid username or password");
        }
    }

    [HttpPost("validate-token")]
    public IActionResult ValidateToken([FromBody] string jwtToken)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _jwtConfiguration.SecurityKey,
                ValidateIssuer = true,
                ValidIssuer = _jwtConfiguration.TokenIssuer,
                ValidateAudience = true,
                ValidAudience = _jwtConfiguration.TokenAudience,
                ValidateLifetime = true
            };

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(jwtToken, validationParameters, out validatedToken);

            return Ok(new { isValid = true, message = "Token is valid." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { isValid = false, message = ex.Message });
        }
    }
    
}


