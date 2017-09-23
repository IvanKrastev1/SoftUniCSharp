namespace _02_03.Employees
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new MyDbContext())
            {

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                
            }
        }
    }
}
