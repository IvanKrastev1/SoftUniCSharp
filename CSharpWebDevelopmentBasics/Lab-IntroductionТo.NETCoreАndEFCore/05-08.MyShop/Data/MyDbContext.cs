using System;

namespace _05_08.MyShop
{
    using Microsoft.EntityFrameworkCore;
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ShopDb;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Salesman)
                .WithMany(s => s.Customers)
                .HasForeignKey(c => c.SalesmanId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Reviews)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<ItemsOrders>()
                .HasKey(io => new { io.ItemId, io.OrderId });

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Orders)
                .WithOne(io => io.Item)
                .HasForeignKey(io => io.ItemId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(io => io.Order)
                .HasForeignKey(io => io.OrderId);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Reviews)
                .WithOne(r => r.Item)
                .HasForeignKey(i => i.ItemId);
        }
    }
}