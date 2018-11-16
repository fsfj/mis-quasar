using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MIS_API.Data;
using MIS_API.Models;

namespace MIS_API.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public AttendanceRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Attendance>> GetAll()
        {
            using (var conn = _connectionFactory.Connection)
            {
                var attendance = await conn.QueryAsync<Attendance, Members, Attendance>("Attendace_GetAll",
                    (a, b) =>
                    {
                        a.Member = b;
                        return a;
                    });

                return attendance.ToList();
            }
        }
    }
}
