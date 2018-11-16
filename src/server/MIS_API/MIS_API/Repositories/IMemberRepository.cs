using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MIS_API.Dtos;
using MIS_API.Models;

namespace MIS_API.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<GetMemberDto>> GetAll();
        Task<Members> GetById(int id);
        Task Insert(Members member);
        Task Update(Members member);
        Task Delete(int id);
    }
}
