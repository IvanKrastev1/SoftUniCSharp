using CarPartsStore.Common.Mapping;
using CarPartsStore.Data;
using CarPartsStore.Data.Enums;
using CarPartsStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.Web.Areas.Admin.Models
{
    public class AdminAddCarFormModel : IMapFrom<Car>
    {
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
