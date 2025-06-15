
using DET.Booking.BusinessLogic.Interfaces;
using DET.Booking.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Twilio.Http;

namespace DET.Booking.BusinessLogic
{
    public class User : IUser
    {
        private readonly DataAccess.Interfaces.IUser? _user;
        private readonly IConfiguration configuration;

        public User(DataAccess.Interfaces.IUser? user, IConfiguration configuration)
        {
            this._user = user;
            this.configuration = configuration;
        }

        public Task<Response<int>> RegisterUser(Models.User user)
        {
            // Hasheamos la contraseña antes de enviarla a la bd
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

            return _user.RegisterUser(user);
        }

        public async Task<Response<Token>> LoginAsync(Models.User user)
        {
            var result = await _user.GetUser(user.Email);
            if (result == null || !BCrypt.Net.BCrypt.Verify(user.Password, result.PasswordHash))
            {
                return new Response<Token> { IsSuccess = false, Message = "Credenciales incorrectas." };
            }

            var token = GenerarToken(result);
            return new Response<Token>
            {
                IsSuccess = true,
                Message = "Login exitoso.",
                Content = new Token
                {
                    BaerToken = token
                }
            };
        }

        private string GenerarToken(Models.User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.RolName ?? "Admin")
        };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
