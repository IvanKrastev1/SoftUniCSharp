namespace CarPartsStore.Data.Models
{
    public class PartSale
    {
        public int PartId { get; set; }

        public Part Part { get; set; }

        public int SaleId { get; set; }

        public Sale Sale { get; set; }
    }
}
