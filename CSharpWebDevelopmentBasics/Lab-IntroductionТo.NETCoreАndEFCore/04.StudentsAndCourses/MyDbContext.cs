using System;

namespace _04.StudentsAndCourses
{
    using Microsoft.EntityFrameworkCore;
    internal class MyDbContext : DbContext
    { 


    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    optionsBuilder.UseSqlServer(@"Server=.;Database=StudentsCourses;Integrated Security=True");

    base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<StudentsCourses>()
    .HasKey(sc => new { sc.StudentId, sc.CourseId });

    modelBuilder.Entity<Student>()
    .HasMany(s => s.Courses)
        .WithOne(sc => sc.Student)
        .HasForeignKey(sc => sc.StudentId);

    modelBuilder.Entity<Course>()
    .HasMany(c => c.Students)
        .WithOne(sc => sc.Course)
        .HasForeignKey(sc => sc.CourseId);

        base.OnModelCreating(modelBuilder);
    }
}
}