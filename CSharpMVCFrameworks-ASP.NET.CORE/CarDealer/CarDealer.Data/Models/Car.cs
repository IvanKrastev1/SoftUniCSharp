﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        public long TravelledDistance { get; set; }

        public IList<PartCar> Parts { get; set; } = new List<PartCar>();

        public IList<Sale> Sales { get; set; } = new List<Sale>();
    }
}
