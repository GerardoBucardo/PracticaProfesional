﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrWebN_Capas.EN
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public int RoleId { get; set; }
        public Role? Roles { get; set; }
    }
}
