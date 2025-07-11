using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using SmartwayFinal.Models;

namespace SmartwayFinal.Services;

public class JWTHandler
{
    private readonly JwtOptions _opt;
    private readonly byte[] _keyBytes;

     public JWTHandler(IOptions<JwtOptions> opt)
    {
        _opt = opt.Value;
        _keyBytes = Encoding.UTF8.GetBytes(_opt.Key);
    }
    
    
    public string GenerateToken(Agente agente)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, $"{agente.Nombre} {agente.Apellidos}"),
            new(ClaimTypes.NameIdentifier, agente.Id.ToString()),
            
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_keyBytes), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _opt.Issuer,
            Audience = _opt.Audience

        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
   
}