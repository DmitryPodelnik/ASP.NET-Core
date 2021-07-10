using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models
{
    [Table("Categories")]
    public class Category
    {
        [Column("Id")]  // Можно было не указывать потому, что так было бы по умолчанию, благодаря соглашению о наименованиях EF
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter a name of product")]
        [DataType(DataType.Text)]
        [MinLength(10)]
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
