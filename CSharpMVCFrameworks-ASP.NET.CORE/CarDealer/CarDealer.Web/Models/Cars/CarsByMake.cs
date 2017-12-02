using CarDealer.Data.Models;
using CarDealer.Services.Cars.Models;
using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Cars
{
    public class CarsByMake
    {
        public IEnumerable<CarModel> Cars { get; set; }

        public string Make { get; set; }
    }
}
