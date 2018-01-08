using CarPartsStore.Common.Mapping;
using CarPartsStore.Data;
using CarPartsStore.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarPartsStore.Services.Models
{
    public class AdminPartListingModel : IMapFrom<Part>
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

        [Required]
        [Display(Name = "Car")]
        public int CarId { get; set; }

        public IEnumerable<AdminCarListingModel> Cars { get; set; }

    }
    
}
