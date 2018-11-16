using System.Collections.Generic;
using System.Threading.Tasks;
using MIS_API.Models;

namespace MIS_API.Repositories
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAll();
    }
}