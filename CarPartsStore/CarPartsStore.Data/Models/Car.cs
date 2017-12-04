using CarPartsStore.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarPartsStore.Data.Models
{
    public class Car
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

        public DateTime Year { get; set; }
        [Required]
        [MinLength(DataConstants.CarMotorMinLength)]
        [MaxLength(DataConstants.CarMotorMaxLength)]
        public string Motor { get; set; }
        [Required]
        public FuelType Fuel { get; set; }

        public IList<Part> Parts { get; set; } = new List<Part>();

    }
}
