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
                  new Order { Id = 1, NoteContent = "Admin order 1", UserId = 1, Number = "432342", OrderDate = DateTime.Now, Status = "Completed" },
                  new Order { Id = 2, NoteContent = "Admin order 2", UserId = 2, Number = "432343", OrderDate = DateTime.Now, Status = "Active" },
                  new Order { Id = 3, NoteContent = "Admin order 3", UserId = 2, Number = "432344", OrderDate = DateTime.Now, Status = "New Order" },
                  new Order { Id = 4, NoteContent = "Admin order 4", UserId = 1, Number = "432345", OrderDate = DateTime.Now, Status = "Waiting for the client at the pickup point" },
              });
        }
    }
}
