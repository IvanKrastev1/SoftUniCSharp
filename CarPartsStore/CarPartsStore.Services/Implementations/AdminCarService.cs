namespace CarPartsStore.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using CarPartsStore.Data;
    using CarPartsStore.Data.Enums;
    using CarPartsStore.Data.Models;
    using CarPartsStore.Services.Interfaces;
    using CarPartsStore.Services.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminCarService : IAdminCarService
    {
        private readonly CarPartsStoreDbContext db;

        public AdminCarService(CarPartsStoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminCarListingModel> All()
        {
            var cars = this
                .db
                .Cars
                .ProjectTo<AdminCarListingModel>()
                .ToList();

            return cars;
        }

        public void Delete(int id)
        {
            var car = this
                .db
                .Cars
                .FirstOrDefault(u => u.Id == id);
            db.Remove(car);
            db.SaveChanges();
        }

        public AdminCarEditModel CarById(int id)
        {
            var car = db
            .Cars
            .Where(i => i.Id == id)
            .ProjectTo<AdminCarEditModel>()
            .FirstOrDefault();
            return car;
        }

        public void EditCar(int id, string make, string model, string year, FuelType fuel, string motor)
        {
            if (IsValidCar(id))
            {
                var car = db
               .Cars
               .FirstOrDefault(i => i.Id == id);

                car.Make = make;
                car.Model = model;
                car.Year = year;
                car.Fuel = fuel;
                car.Motor = motor;

                db.SaveChanges();
            }
        }

        public void AddCar(string make, string model, string year, FuelType fuel, string motor)
        {
            var car = new Car()
            {
                Make = make,
                Model = model,
                Year = year,
                Fuel = fuel,
                Motor = motor
            };
                
            db.Cars.Add(car);
            db.SaveChanges();
        }

        private bool IsValidCar(int id)
        {
            return db.Cars.Any(k => k.Id == id);
        }
    }
}
