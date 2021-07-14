using Microsoft.EntityFrameworkCore;
using _01._07._21_EXAM_Internet_Shop.Models;
using _01._07._21_EXAM_Internet_Shop.Models.Database.Configurations;

namespace _01._07._21_EXAM_Online_Store
{
    public  class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options)
        {
            // Если такая БД уже есть, то удаляем ее
            //if (Database.CanConnect())
                //Database.EnsureDeleted();

            // Создаем БД
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Выводим в режиме отладки запросы, отправляемые EF, в окно Output (меню Visual Studio: View -> Output).
            // Метод DbContextOptionsBuilder.LogTo был добавлен только начиная с EF Core 5.0.
            optionsBuilder.LogTo(s => System.Diagnostics.Debug.WriteLine(s));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}