using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MIS_API.Dtos;
using MIS_API.Models;

namespace MIS_API.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetMemberDto, Members>();
        }
    }
}
