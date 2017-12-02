using System.ComponentModel.DataAnnotations;

namespace CarDealer.Data.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public int Discount { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
