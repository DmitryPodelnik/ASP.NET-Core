using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
             SHA256Managed sha256 = new SHA256Managed();

            builder.HasData(
              new User[]
              {
                    new User { Id = 1,  Username = "dmitrypodelnik", Password = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes("12341234qwe"))),
                               Email = "dmitrypodelnik.developer@gmail.com", RoleId = 1, FirstName = "Dmitry", LastName = "Podelnik", Country = "Ukraine" },
                    new User { Id = 2,  Username = "dmitrypodelnik2", Password = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes("12341234qwe"))),
                               Email = "dmitrypodelnik.developer@gmail.com", RoleId = 2, FirstName = "Dmitry", LastName = "Podelnik", Country = "Ukraine" },
              });
        }
    }
}
