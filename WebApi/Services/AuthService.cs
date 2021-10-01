using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class AuthService
    {
        private static readonly string _secret = Guid.NewGuid().ToString();
        public static byte[] Key = Encoding.Default.GetBytes(_secret);

        private IService<User> _service;

        public AuthService(IService<User> service)
        {
            _service = service;
        }

        public string Authenticate(string login, string password)
        {
            var user = _service.Read().SingleOrDefault(x => x.Login == login);
            if (user == null || user.Password != password)
                return null;

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Login));
            claims.Add(new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString()));
            claims.AddRange(user.Roles.ToString().Split(",").Select(x => new Claim(ClaimTypes.Role, x.Trim())));


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor();
            tokenDescriptor.Subject = new System.Security.Claims.ClaimsIdentity(claims);
            tokenDescriptor.Expires = DateTime.Now.AddMinutes(5);
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature);

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
