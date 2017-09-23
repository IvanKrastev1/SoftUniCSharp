namespace _01.StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    public class StudentSystemDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=.;Database=StudentSystemDb;Integrated Security=true");

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourse>()
                .HasKey(sc => new {sc.StudentId, sc.CourseId});

            builder
                .Entity<Student>()
                .HasMany(c => c.Courses)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            builder
                .Entity<Course>()
                .HasMany(s => s.Students)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            builder
                .Entity<Course>()
                .HasMany(r => r.Resources)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            builder
                .Entity<Course>()
                .HasMany(h => h.Homeworks)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            builder
                .Entity<Student>()
                .HasMany(h => h.Homeworks)
                .WithOne(S => S.Student)
                .HasForeignKey(s => s.StudentId);

            base.OnModelCreating(builder);
        }
    }
}
