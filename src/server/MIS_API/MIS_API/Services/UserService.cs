using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MIS_API.Data;
using MIS_API.Helpers;
using MIS_API.Models;

namespace MIS_API.Services
{
    public class UserService: IUserService
    {
        //private List<User> _users = new List<User>
        //{
        //    new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        //};
        private readonly IConnectionFactory _connectionFactory;
        private readonly AppSettings _appSettings;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public UserService(IOptions<AppSettings> appSettings,
            IConnectionFactory connectionFactory)
        {
            _appSettings = appSettings.Value;
            _connectionFactory = connectionFactory;
        }
        
        public User Authenticate(string username, string password)
        {
            using (var conn = _connectionFactory.Connection)
            {
                var user = conn.QueryFirstOrDefault<User>("User_Login",
                    new { username },
                    commandType: CommandType.StoredProcedure);
                // return null if user not found
                if (user == null)
                    return null;

                if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Success)
                    return null;
                // authentication successful so generate jwt token
                user.Token = GenerateToken(user);
                //if (user.Token != GenerateToken(user))
                //    return null;

                // remove password before returning
                user.PasswordHash = null;

                return user;
            }
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            //return _users.Select(x =>
            //{
            //    x.PasswordHash = null;
            //    return x;
            //});
            return new List<User>();
        }

        public async Task Register(User user, string password)
        {
            using (var conn = _connectionFactory.Connection)
            {
                try
                {
                    var hashedPassword = _passwordHasher.HashPassword(user, password);
                    user.Token = GenerateToken(user);
                    user.PasswordHash = hashedPassword;
                    await conn.ExecuteAsync("User_Register", user, commandType: CommandType.StoredProcedure);

                    
                    //return user;
                }
                catch (Exception exception)
                {
                    //return null;
                }

            }
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "Admin") 
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
