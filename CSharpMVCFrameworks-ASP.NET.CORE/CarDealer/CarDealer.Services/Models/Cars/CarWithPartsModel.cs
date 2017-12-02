using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models.Cars
{
    public class CarWithParts
    {
        public int Id { get; set; }

        public string Make { get; set;}

        public string Model { get; set; }

        public long TravelledDistance { get; set;}

        public IList<PartsModel> Parts { get; set; }
    }
}
