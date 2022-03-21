using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PaymentSystem.Helpers;
using PaymentSystem.Interfaces.IServices;
using PaymentSystem.Models;
using PaymentSystem.Requests;
using PaymentSystem.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Services
{
    public class AuthService : IAuthService
    {
        private PaymentSystemDBContext _context = new();
        private readonly AppSetting _AppSettings;

        public AuthService(IOptions<AppSetting> appSettings)
        {
            _AppSettings = appSettings.Value;
        }

        public AuthResponse AuthLogin(AuthRequest authRequest)
        {
            string password  = HashingHelper.Sha256Hash(authRequest.Password);
            string email     = authRequest.Email;
            var authResponse = new AuthResponse();

            var query = _context.Users.Where(user => user.Password == password && user.Email == email)
                .FirstOrDefault();

            if (query == null)
            {
                return null;
            }

            authResponse.Email = query.Email;
            authResponse.Token = TokenGenerator(query);

            return authResponse;

        }

        public string TokenGenerator(User user)
        {
            var tokenHandler    = new JwtSecurityTokenHandler();
            var key             = Encoding.ASCII.GetBytes(_AppSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),

                Expires = DateTime.UtcNow.AddMinutes(30),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )

            };

            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
