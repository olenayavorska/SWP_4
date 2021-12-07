using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWP_4.Models
{
    public class LoginModel { 
        [Required(ErrorMessage = "enter mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

