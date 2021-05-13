using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Users_14._05._21.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Enter an username")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Incorrect length")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter a password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Incorrect length")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Password Confirmation")]
        //[Required(ErrorMessage = "Incorrect password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Incorrect length")]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        public string PasswordConfirmation { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter an email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(320, ErrorMessage = "Incorrect length")]
        public string Email { get; set; }
    }
}
