namespace CarPartsStore.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using CarPartsStore.Data;
    using CarPartsStore.Data.Enums;
    using CarPartsStore.Data.Models;
    using CarPartsStore.Services.Interfaces;
    using CarPartsStore.Services.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarService : ICarService
    {
        private readonly CarPartsStoreDbContext db;

        public CarService(CarPartsStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminCarListingModel>> All()
        {
            var cars = this
                .db
                .Cars
                .ProjectTo<AdminCarListingModel>()
                .ToListAsync();

            return await cars;
        }

        public async Task Delete(int id)
        {
            var car = await this
                .db
                .Cars
                .SingleOrDefaultAsync(u => u.Id == id);
            this.db.Remove(car);
            await db.SaveChangesAsync();
        }

        public async Task<AdminCarEditModel> CarById(int id)
        {
            var car = await this.db
            .Cars
            .Where(i => i.Id == id)
            .ProjectTo<AdminCarEditModel>()
            .SingleOrDefaultAsync();

            return car;
        }

        public async Task EditCar(int id, string make, string model, string year, FuelType fuel, string motor)
        {
            if (await IsValidCar(id))
            {
                var car = await this.db
               .Cars
               .SingleOrDefaultAsync(i => i.Id == id);

                car.Make = make;
                car.Model = model;
                car.Year = year;
                car.Fuel = fuel;
                car.Motor = motor;

                await db.SaveChangesAsync();
            }
        }

        public async Task AddCar(string make, string model, string year, FuelType fuel, string motor)
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
            await db.SaveChangesAsync();
        }

        private async Task<bool> IsValidCar(int id)
        {
            return await db.Cars.AnyAsync(k => k.Id == id);
        }
    }
}
