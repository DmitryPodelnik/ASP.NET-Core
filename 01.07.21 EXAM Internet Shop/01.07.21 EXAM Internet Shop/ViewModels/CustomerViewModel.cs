using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.ViewModels
{
    public class CustomerViewModel
    {
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
    }
}
