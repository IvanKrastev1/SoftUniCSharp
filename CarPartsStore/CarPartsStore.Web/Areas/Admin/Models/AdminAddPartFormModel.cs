using CarPartsStore.Common.Mapping;
using CarPartsStore.Data;
using CarPartsStore.Data.Models;
using CarPartsStore.Services.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarPartsStore.Web.Areas.Admin.Models
{
    public class AdminAddPartFormModel : IMapFrom<Part>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.PartNameMinLength)]
        [MaxLength(DataConstants.PartNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(DataConstants.PartPriceMinLength,DataConstants.PartPriceMaxLength)]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Car")]
        public int CarId { get; set; }

        public IEnumerable<AdminCarListingModel> Cars { get; set; }
    }
}
