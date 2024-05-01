﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Models
{
    public class AdminUser
    {
       
        public int Id { get; set; }
        public string UserName { get; set; }
        public String Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
