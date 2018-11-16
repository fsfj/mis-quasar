using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_API.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public Members Member { get; set; }
        public int MemberId { get; set; }
        public DateTime DateAttended { get; set; }
    }
}
