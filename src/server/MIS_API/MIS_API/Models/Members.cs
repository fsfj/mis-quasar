using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_API.Models
{
    public class Members
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int ContactNumber { get; set; }
        public int Kapisanan { get; set; }
        public string Occupation { get; set; }
        public bool IsBaptized { get; set; }
        public DateTime SpiritualBirthDate { get; set; }
    }
}
