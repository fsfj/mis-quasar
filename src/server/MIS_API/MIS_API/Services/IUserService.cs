using System.Collections.Generic;
using MIS_API.Models;

namespace MIS_API.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}