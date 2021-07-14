using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models
{
    [Table("Users")]
    public class User
    {
        [Column("Id")]  // Можно было не указывать потому, что так было бы по умолчанию, благодаря соглашению о наименованиях EF
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Enter a username")]
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Incorrect length")]
        public string Username { get; set; }

        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "Enter a firstname")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Enter a lastname")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Incorrect length")]
        public string LastName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter a password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Incorrect length")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Password Confirmation")]
        //[Required(ErrorMessage = "Incorrect password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        public string PasswordConfirmation { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter an email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(320, ErrorMessage = "Incorrect length")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Incorrect length")]
        public string Country { get; set; }

        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}
