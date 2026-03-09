using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dev.UAA3.Backend.Presentation.WebAPI.Tools
{
    public class TokenTool
    {
        private readonly IConfiguration _config;
        public TokenTool(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJWT(int memberId)
        {
            Claim[] claims = [
                new Claim(ClaimTypes.NameIdentifier, memberId.ToString()),
            ];

            string secret = _config["Token:Key"] ?? throw new Exception("Clef du token non configuré");
            byte[] key = Encoding.UTF8.GetBytes(secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            JwtSecurityToken token = new JwtSecurityToken(
                  issuer: _config["Token:Issuer"],
                  audience: _config["Token:Audience"],
                  expires: DateTime.Now.AddMinutes(_config.GetValue<int>("Token:Expire")),
                  claims: claims,
                  signingCredentials: signingCredentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
