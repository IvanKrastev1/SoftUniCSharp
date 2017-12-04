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

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<PartSale>()
                .HasKey(pa => new { pa.PartId, pa.SaleId });

            builder
                .Entity<PartSale>()
                .HasOne(p => p.Part)
                .WithMany(s => s.Sales)
                .HasForeignKey(fk => fk.PartId);

            builder
                .Entity<PartSale>()
                .HasOne(s => s.Sale)
                .WithMany(p => p.Parts)
                .HasForeignKey(fk => fk.SaleId);

            builder
                .Entity<Sale>()
                .HasOne(u => u.User)
                .WithMany(s => s.Sales)
                .HasForeignKey(u => u.UserId);

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
