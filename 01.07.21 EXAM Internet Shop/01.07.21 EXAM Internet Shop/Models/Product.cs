using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models
{
    [Table("Products")]
    public class Product
    {
        [Column("Id")]  // Можно было не указывать потому, что так было бы по умолчанию, благодаря соглашению о наименованиях EF
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter a name of product")]
        [DataType(DataType.Text)]
        [MinLength(3)]
        public string Name { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "Enter a product content")]
        [DataType(DataType.Text)]
        [MinLength(10)]
        public string Content { get; set; }

        [Display(Name = "Image")]
        [DataType(DataType.Text)]
        [Required]
        public string Image { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [Required]
        public double Price { get; set; }

        [Display(Name = "Seller")]
        [Required(ErrorMessage = "Enter a seller")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string Seller { get; set; }

        [Required]
        public int Code { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        //public List<Cart> Carts { get; set; } = new();
    }
}
