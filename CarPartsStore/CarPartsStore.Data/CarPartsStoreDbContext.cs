namespace CarPartsStore.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CarPartsStoreDbContext : IdentityDbContext<User>
    {
        public CarPartsStoreDbContext(DbContextOptions<CarPartsStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(a => a.User)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Part>()
                .HasMany(x => x.Orders)
                .WithOne(a => a.Part)
                .HasForeignKey(x => x.PartId);

            builder
                .Entity<Message>()
                .HasOne(u => u.User)
                .WithMany(s => s.Messages)
                .HasForeignKey(u => u.UserId);

            builder
                .Entity<Part>()
                .HasOne(p => p.Car)
                .WithMany(c => c.Parts)
                .HasForeignKey(fk => fk.CarId);

            base.OnModelCreating(builder);
        }
    }
}
