using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Orders_Validation_10._05._21.Models
{
    public class Order
    {
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Name must be between 6 adn 50 symbols")]
        [Required(ErrorMessage = "You must enter a name")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter an address")]
        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must enter an email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter a date")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required(ErrorMessage = "You must enter the terms accepted")]
        [Display(Name = "Terms Accepted")]
        public bool TermsAccepted { get; set; }
    }
}
