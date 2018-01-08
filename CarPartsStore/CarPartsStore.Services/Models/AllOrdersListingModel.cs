using CarPartsStore.Common.Mapping;
using CarPartsStore.Data.Models;

namespace CarPartsStore.Services.Models
{
    public class AllOrdersListingModel:IMapFrom<Order>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int PartId { get; set; }

        public User User { get; set; }

        public Part Part { get; set; }

        public string Address { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsDelivered { get; set; }
    }
}
