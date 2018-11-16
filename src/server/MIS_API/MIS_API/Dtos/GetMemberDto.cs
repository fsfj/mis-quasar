using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MIS_API.Models;

namespace MIS_API.Dtos
{
    public class GetMemberDto : Members
    {
        public string Name => $"{Firstname} {Middlename} {Lastname}";
    }
}
