using CarDealer.Data.Models;
using CarDealer.Services.Models.Cars;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Cars
{
    public class CarWithPartsModel
    {
        public Car Car { get; set; }

        public IEnumerable<PartsModel> Parts { get; set; }
    }
}
