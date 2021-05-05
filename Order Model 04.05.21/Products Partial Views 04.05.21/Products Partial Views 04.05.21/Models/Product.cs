using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Products_Partial_Views_04._05._21.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime CreatedDate { get; set; }

        public Product () { }
        public Product (int id, string name, double price, DateTime createdDate)
        {
            Id = id;
            Name = name;
            Price = price;
            CreatedDate = createdDate;
        }
    }
}
