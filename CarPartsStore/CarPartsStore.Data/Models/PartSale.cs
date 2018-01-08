namespace CarPartsStore.Data.Models
{
    public class PartSale
    {
        public int PartId { get; set; }

        public Part Part { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
