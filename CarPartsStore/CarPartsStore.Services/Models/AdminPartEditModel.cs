using CarPartsStore.Common;
using CarPartsStore.Common.Mapping;
using CarPartsStore.Data;
using CarPartsStore.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarPartsStore.Services.Models
{
    public class AdminPartEditModel : IMapFrom<Part>
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
        [Display(Name = PartsConst.DisplayCar)]
        public int CarId { get; set; }

        [Required]
        [MinLength(DataConstants.PartNameMinLength)]

        [Display(Name = PartsConst.DisplayImageUrl)]
        public string ImageUrl { get; set; }

        public IEnumerable<AdminCarListingModel> Cars { get; set; }
    }
}
