using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
              new Role[]
              {
                    new Role { Id = 1, Name = "admin" },
                    new Role { Id = 2, Name = "user" }
              });
        }
    }
}
