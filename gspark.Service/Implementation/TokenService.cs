using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using gspark.Domain.Identity;
using gspark.Service.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace gspark.Service.Implementation;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config)
    {
        _config = config;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
    }

    public string CreateToken(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.DisplayName)
        };

        var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = cred,
            Issuer = _config["JWT:ValidIssuer"],
            Audience = _config["JWT:ValidAudience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}