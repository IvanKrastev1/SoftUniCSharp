namespace CarPartsStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Part
    {
        public int Id { get; set; }
        [Required]
        [MinLength(DataConstants.PartNameMinLength)]
        [MaxLength(DataConstants.PartNameMaxLength)]
        public string Name { get; set; }
        [Required]
        [MinLength(DataConstants.PartPriceMinLength)]
        [MaxLength(DataConstants.PartPriceMaxLength)]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public List<PartSale> Sales { get; set; } = new List<PartSale>();
    }
}
