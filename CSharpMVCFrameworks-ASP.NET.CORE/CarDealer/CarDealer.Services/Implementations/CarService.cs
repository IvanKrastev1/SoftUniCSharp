using CarDealer.Data;
using CarDealer.Services.Cars.Models;
using CarDealer.Services.Models.Cars;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarModel> ByMake(string make)
        {
            return this
                .db
                .Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .OrderBy(c => c.Model)
                .ThenBy(c => c.TravelledDistance)
                .Select(c => new CarModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();
        }

        public IEnumerable<CarWithParts> CarWithParts(int id)
        {
            return this
                .db
                .Cars
                .Where(c => c.Id == id)
                .Select(c => new CarWithParts
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c
                    .Parts
                    .Where(hc => hc.CarId == id)
                    .Select(hc => new PartsModel
                    {
                        Id = hc.Part.Id,
                        Name = hc.Part.Name,
                        Price = hc.Part.Price
                    })
                    .ToList()
                })
                .ToList();
        }
    }
}
