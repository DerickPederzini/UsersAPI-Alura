
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserAPI.Models;
namespace UserAPI.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration) 
        {

            _configuration = configuration;

        }

        public string GenerateToken(User user)
        {
            Claim[] claim = new Claim[] 
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString()),
                new Claim("LoginTimeStemp", DateTime.UtcNow.ToString())
            };
 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddDays(10),
                claims: claim,
                signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}