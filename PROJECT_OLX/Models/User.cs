﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJECT_OLX.Models;
using System.ComponentModel.DataAnnotations;

namespace PROJECT_OLX.Models
{
    public class User
    {
        [Key]
        public string Name { get; set; }
        public string Password { get; set; }
        public string Logged { get; set; }
        public string FirstName { get; set; }
        public string AvatarPath { get; set; }
        public string AvatarName { get; set; }
        public string Desc { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Add> Adds = new();
    }
}
