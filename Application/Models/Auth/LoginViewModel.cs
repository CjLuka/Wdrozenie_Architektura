﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Auth
{
    public class LoginViewModel
    {
        [Display(Name ="Email Address")]
        public string Email{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
    }
}
