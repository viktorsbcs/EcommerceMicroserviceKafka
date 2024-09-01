using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var orderProductOne = new OrderProduct()
            {
                Id = Guid.NewGuid(),
                OrderId = Guid.Parse("afeac771-9c94-411b-8cf7-55e8ed19c63f"),
                ProductId = Guid.Parse("649febd9-966f-40f0-b7bf-f2ad274155b2"),
                Quantity = 4
            };

            var orderProductTwo = new OrderProduct()
            {
                Id = Guid.NewGuid(),
                OrderId = Guid.Parse("afeac771-9c94-411b-8cf7-55e8ed19c63f"),
                ProductId = Guid.Parse("348fab00-3f70-4b84-a168-aa77e7bf3097"),
                Quantity = 12
            };

            var orderProductThree = new OrderProduct()
            {
                Id = Guid.NewGuid(),
                OrderId = Guid.Parse("95613f1f-1e2c-4d74-92a6-cf85a3258271"),
                ProductId = Guid.Parse("b7522a9d-1a57-4b93-a080-edf724da627f"),
                Quantity = 32
            };
            var seedOrderProducts = new List<OrderProduct>() { orderProductOne, orderProductTwo, orderProductThree };

            var seedOrders = new List<Order>()
            {
                new Order()
                {
                    Id = Guid.Parse("afeac771-9c94-411b-8cf7-55e8ed19c63f"),
                    CustomerEmail = "john5@mail.com",
                    OrderDate = DateTime.Now,
                    //OrderProducts = new List<OrderProduct>(){ orderProductOne, orderProductTwo }
                },
                new Order()
                {
                    Id = Guid.Parse("95613f1f-1e2c-4d74-92a6-cf85a3258271"),
                    CustomerEmail = "jake12@mail.com",
                    OrderDate = DateTime.Now,
                    //OrderProducts = new List<OrderProduct>(){ orderProductThree }
                }
            };

            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<OrderProduct>().HasKey(op => op.Id);
            modelBuilder.Entity<OrderProduct>().HasOne(op => op.Order).WithMany(o => o.OrderProducts).HasForeignKey(o => o.OrderId);
            //modelBuilder.Entity<Order>().HasMany(o => o.OrderProducts).WithOne(op => op.Order).HasForeignKey(op => op.OrderId);
            modelBuilder.Entity<OrderProduct>().HasData(seedOrderProducts);
            modelBuilder.Entity<Order>().HasData(seedOrders);

            base.OnModelCreating(modelBuilder);
        }
    }
}
