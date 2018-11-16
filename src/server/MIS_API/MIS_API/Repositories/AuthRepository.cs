using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MIS_API.Data;
using MIS_API.Models;

namespace MIS_API.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        //private readonly IConnectionFactory _connectionFactory;
        //public AuthRepository(IConnectionFactory connectionFactory)
        //{
        //    _connectionFactory = connectionFactory;
        //}
        //public async Task<User> Register(User user, string password)
        //{
        //    using (var conn = _connectionFactory.Connection)
        //    {
        //        try
        //        {
        //            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
        //            user.PasswordHash = passwordHash;
        //            user.PasswordSalt = passwordSalt;
        //            await conn.ExecuteAsync("User_Register", user, commandType: CommandType.StoredProcedure);
        //            return user;
        //        }
        //        catch (Exception exception)
        //        {
        //            return null;
        //        }
              
        //    }
        //}

        //public async Task<User> Login(string username, string password)
        //{
        //    using (var conn = _connectionFactory.Connection)
        //    {
        //        try
        //        {
        //            var user = (await conn.QueryAsync<User>("User_Login",
        //                new { username = username },
        //                commandType: CommandType.StoredProcedure)).SingleOrDefault();

        //            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        //            {
        //                return null;
        //            }

        //            return user;    
        //        }
        //        catch (Exception ex)
        //        {
        //            return new User();
        //        }
                
        //    }
        //}

        //private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512(passwordSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != passwordHash[i])
        //            {
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
        //}

        //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //    }
        //}

        //public async Task<bool> UserExists(string username)
        //{
        //    using (var conn = _connectionFactory.Connection)
        //    {
        //        var user = await conn.QueryAsync<User>("User_Login", new {username = username});

        //        if (user.Any())
        //            return true;

        //        return false;
        //    }
        //}
    }
}
