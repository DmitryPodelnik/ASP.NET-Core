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

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter an name")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string Name { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Enter an name")]
        public uint Amount { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter an name")]
        public Address Address { get; set; }

        [Display(Name = "Comments")]
        public string NoteContent { get; set; }

        [Display(Name = "Seller")]
        public string CustomerName { get; set; }

        [Display(Name = "Дата доставки")]
        public DateTime DeliveryDate { get; set; }
    }
}
