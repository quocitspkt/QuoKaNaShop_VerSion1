﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoKaNaShop.Model.Models
{
    [Table("Admins")]
    public class Admin
    {
        [Key]
        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Photo { get; set; }
    }
}
