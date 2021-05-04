using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Model_04._05._21.Models
{
    public class Order
    {
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Количество")]
        public uint Amount { get; set; }

        [Display(Name = "Адрес")]
        public Address Address { get; set; }

        [Display(Name = "Содержимое записки")]
        public string NoteContent { get; set; }

        [Display(Name = "Имя заказчика")]
        public string CustomerName { get; set; }

        [Display(Name = "Дата доставки")]
        public DateTime DeliveryDate { get; set; }

        public Order() { }
        public Order(string name, uint amount, Address address, string noteContent, string customerName, DateTime deliveryTime)
        {
            Name = name;
            Amount = amount;
            Address = address;
            NoteContent = noteContent;
            CustomerName = customerName;
            DeliveryDate = deliveryTime;
        }


    }
}
