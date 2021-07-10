using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models.Database.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
              new Category[]
              {
                  new Category { Id = 1, Name = "Laptops and PC" },
                  new Category { Id = 2, Name = "Phones" },
                  new Category { Id = 3, Name = "Goods for gamers" },
                  new Category { Id = 4, Name = "Household products" },
                  new Category { Id = 5, Name = "Household appliances" },
                  new Category { Id = 6, Name = "Sports and hobbies" },
                  new Category { Id = 7, Name = "Children's products" },
                  new Category { Id = 8, Name = "Food" },
              });
        }
    }
}
