using CarPartsStore.Data;
using CarPartsStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarPartsStore.Services.Models
{
    public class AdminAllPartsListingModel
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

        public Car Car { get; set; }
    }
}
