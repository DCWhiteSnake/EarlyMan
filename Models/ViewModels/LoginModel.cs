using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EarlyMan.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        [RegularExpression(".+\\@.+\\..+",
           ErrorMessage = "Please enter a valid email address")]
        [UIHint("email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}