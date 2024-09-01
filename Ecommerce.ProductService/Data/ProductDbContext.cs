using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Ecommerce.ProductService.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seedProducts = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.Parse("649febd9-966f-40f0-b7bf-f2ad274155b2"),
                    Name = "Product #1",
                    Price = 38.99m,
                    StockQuantity = 95
                },
                new Product()
                {
                    Id = Guid.Parse("348fab00-3f70-4b84-a168-aa77e7bf3097"),
                    Name = "Product #2",
                    Price = 84.99m,
                    StockQuantity = 43
                },
                new Product()
                {
                    Id = Guid.Parse("b7522a9d-1a57-4b93-a080-edf724da627f"),
                    Name = "Product #3",
                    Price = 149.99m,
                    StockQuantity = 21
                }
            };

            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal");
            modelBuilder.Entity<Product>().HasData(seedProducts);
            base.OnModelCreating(modelBuilder);
        }


    }
}
