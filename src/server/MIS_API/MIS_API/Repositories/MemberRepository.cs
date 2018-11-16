using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using MIS_API.Data;
using MIS_API.Dtos;
using MIS_API.Models;

namespace MIS_API.Repositories
{
    public class MemberRepository: IMemberRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;
        public MemberRepository(IConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetMemberDto>> GetAll()
        {
            using (var conn = _connectionFactory.Connection)
            {
                var members = await conn.QueryAsync<Members>("Members_GetAll");

                var getMembersDto = _mapper.Map<IEnumerable<GetMemberDto>>(members);
                return getMembersDto;
            }
        }

        public async Task<Members> GetById(int id)
        {
            using (var conn = _connectionFactory.Connection)
            {
                var members = await conn.QueryAsync<Members>("Members_GetById", 
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                return members.SingleOrDefault();
            }
        }

        public async Task Insert(Members member)
        {
            using (var conn = _connectionFactory.Connection)
            {
                await conn.ExecuteAsync("Members_Insert", member, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Update(Members member)
        {
            using (var conn = _connectionFactory.Connection)
            {
                await conn.ExecuteAsync("Members_Update", member, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(int id)
        {
            using (var conn = _connectionFactory.Connection)
            {
                await conn.ExecuteAsync("Members_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
