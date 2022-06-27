using PrimeraAPI.Application.Contracts.Services;
using PrimeraAPI.BusinessModels.Models.Users;
using PrimeraAPI.DataAccess.Contracts.Models;
using PrimeraAPI.DataAccess.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrimeraAPI.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public UserResponse? ValidateUser(LoginRequest request)
        {
            UserDto? user = _userRepository.ValidateUser(request.UserName, request.Password);

            if (user == null)
                return null;

            UserResponse result = new UserResponse
            {
                UserId = user.UserId,
                UserName = user.UserName
            };

            string secret = _configuration.GetSection("AppSettings").GetSection("Secret").Value;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            result.Token = tokenHandler.WriteToken(token);

            return result;

        }
    }
}
