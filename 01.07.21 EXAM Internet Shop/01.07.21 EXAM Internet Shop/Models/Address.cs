using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models
{
    [Table("Addresses")]
    public class Address
    {
        [Column("Id")]  // Можно было не указывать потому, что так было бы по умолчанию, благодаря соглашению о наименованиях EF
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Enter a city")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string City { get; set; }

        [Display(Name = "Street")]
        [Required(ErrorMessage = "Enter a street")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string Street { get; set; }

        [Display(Name = "House")]
        [Required(ErrorMessage = "Enter a house")]
        [DataType(DataType.Text)]
        [MinLength(1)]
        public string House { get; set; }
    }
}
