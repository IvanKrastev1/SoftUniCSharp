using CarPartsStore.Common.Mapping;
using CarPartsStore.Data;
using CarPartsStore.Data.Enums;
using CarPartsStore.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CarPartsStore.Services.Models
{
    public class AdminCarEditModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.CarMakeMinLength)]
        [MaxLength(DataConstants.CarMakeMaxLength)]
        public string Make { get; set; }

        [Required]
        [MinLength(DataConstants.CarModelMinLength)]
        [MaxLength(DataConstants.CarModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MinLength(DataConstants.CarYearMinLength)]
        [MaxLength(DataConstants.CarYearMaxLength)]
        public string Year { get; set; }

        [Required]
        [MinLength(DataConstants.CarMotorMinLength)]
        [MaxLength(DataConstants.CarMotorMaxLength)]
        public string Motor { get; set; }

        [Required]
        public FuelType Fuel { get; set; }
    }
}
