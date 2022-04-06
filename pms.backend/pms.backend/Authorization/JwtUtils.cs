namespace Authorization;

using Newtonsoft.Json.Linq;
using DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Helpers;

public interface IJwtUtils
{
    public string GenerateToken(User user);
}

public class JwtUtils : IJwtUtils
{
    private readonly AppSettings _appSettings;

    public JwtUtils(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _appSettings.Subject),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserId", user.UserId.ToString()),
            new Claim("UserName", user.UserName),
            new Claim("UserEmail", user.UserEmail),
        };
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _appSettings.Issuer,
            _appSettings.Audience,
            claims,
            expires: DateTime.UtcNow.AddHours(1.0),
            signingCredentials: signIn
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

