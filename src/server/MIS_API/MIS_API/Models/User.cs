﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }
        public string PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        public string Token { get; set; }
    }
    //public class User
    //{
    //    public int Id { get; set; }
    //    public string Username { get; set; }
    //    public byte[] PasswordHash { get; set; }
    //    public byte[] PasswordSalt { get; set; }
    //}
}
