namespace _01.StudentSystem
{
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public  static void Main()
        {
            using (var db = new StudentSystemDbContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();
                db.Database.Migrate();
            }
        }
    }
}
