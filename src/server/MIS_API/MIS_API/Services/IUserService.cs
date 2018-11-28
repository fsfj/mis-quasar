using System.Collections.Generic;
using System.Threading.Tasks;
using MIS_API.Models;

namespace MIS_API.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        Task Register(User user, string password);
    }
}