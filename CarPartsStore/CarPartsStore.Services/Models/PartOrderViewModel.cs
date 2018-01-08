namespace CarPartsStore.Services.Models
{
    using CarPartsStore.Common.Mapping;
    using CarPartsStore.Data;
    using CarPartsStore.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class PartOrderViewModel:IMapFrom<Part>
    {
        public int partId { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Car { get; set; }

        [Required]
        [MinLength(DataConstants.AddressMinLenght)]
        public string Address { get; set; }

        [Required]
        [Range(DataConstants.MinQuanityOrder,double.MaxValue)]
        public int Quantity { get; set; }
    }
}
