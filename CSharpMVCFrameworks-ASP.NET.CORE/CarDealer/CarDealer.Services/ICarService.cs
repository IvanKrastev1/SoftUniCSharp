using CarDealer.Services.Cars.Models;
using CarDealer.Services.Models.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services
{
    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarWithParts> CarWithParts(int id);
    }
}
