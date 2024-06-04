using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart.Models;
public class JwtConfiguration
{
    public string TokenIssuer { get; set; }
    public string TokenAudience { get; set; }
    public string SigningKey { get; set; }
    public SymmetricSecurityKey SecurityKey { get; internal set; }
}
