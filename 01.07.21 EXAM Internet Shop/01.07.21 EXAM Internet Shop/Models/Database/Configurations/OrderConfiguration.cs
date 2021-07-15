using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models.Database.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
              new Order[]
              {
                  new Order { Id = 1, NoteContent = "Admin order", UserId = 1, Number = "432342", OrderDate = DateTime.Now, Status = "Completed" },
              });
        }
    }
}
