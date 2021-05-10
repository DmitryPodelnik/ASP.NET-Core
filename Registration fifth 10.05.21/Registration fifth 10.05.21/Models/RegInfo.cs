using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_fifth_10._05._21.Models
{
    public class RegInfo
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "ConfirmationPassword")]
        public string ConfirmationPassword { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
