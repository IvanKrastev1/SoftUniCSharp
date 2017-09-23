using System;

namespace _04.StudentsAndCourses
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                
            }
        }
    }
}
