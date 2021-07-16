using _01._07._21_EXAM_Internet_Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models
{
    [Table("Orders")]
    public class Order
    {
        [Column("Id")]  // Можно было не указывать потому, что так было бы по умолчанию, благодаря соглашению о наименованиях EF
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "Enter an firstname")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Enter an lastname")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string LastName { get; set; }

        [Display(Name = "Number")]
        [Required(ErrorMessage = "Enter an number")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string Number { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Enter an city")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string City { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter an address")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string Address { get; set; }

        //[Display(Name = "Address")]
        //[Required(ErrorMessage = "Enter an address")]
        //public Address Address { get; set; }

        [Display(Name = "Comments")]
        [DataType(DataType.Text)]
        public string NoteContent { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Enter an phone")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(2)]
        public string Phone { get; set; }

        //[Display(Name = "Customer")]
        //public CustomerViewModel Customer { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Products")]
        public List<Product> Products { get; set; } = new();

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Display(Name = "Status")]
        [DataType(DataType.Text)]
        public string Status { get; set; }
    }
}
