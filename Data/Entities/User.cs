﻿using Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int UserId{ get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
        public string Salt { get; set; }
        public UserType Type { get; set; }
    }
}
