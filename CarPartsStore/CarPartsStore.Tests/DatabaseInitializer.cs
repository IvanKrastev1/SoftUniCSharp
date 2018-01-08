using AutoMapper;
using CarPartsStore.Data;
using CarPartsStore.Data.Models;
using CarPartsStore.Web.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPartsStore.Tests
{
    public static class DatabaseInitializer
    {
        public static CarPartsStoreDbContext GetDbForCarService()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var dbOptions = new DbContextOptionsBuilder<CarPartsStoreDbContext>()
               .UseInMemoryDatabase("CarPartsStoreTests").Options;

            var db = new CarPartsStoreDbContext(dbOptions);

            var car1 = new Car
            {
                Fuel = Data.Enums.FuelType.LPG,
                Id = 1,
                Make = "lada",
                Model = "nivada",
                Motor = "olio",
                Year = "1888",
            };
            var car2 = new Car
            {
                Fuel = Data.Enums.FuelType.LPG,
                Id = 2,
                Make = "lada",
                Model = "nivada2",
                Motor = "olio",
                Year = "1888",
            };
            db.AddRange(car1, car2);
            db.SaveChanges();
            return db;
        }



        public static CarPartsStoreDbContext GetDbForPartService()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var dbOptions = new DbContextOptionsBuilder<CarPartsStoreDbContext>()
               .UseInMemoryDatabase("CarPartsStoreTests").Options;

            var db = new CarPartsStoreDbContext(dbOptions);

            var part1 = new Part
            {
                ImageUrl = "asd",
                Name = "stefan",
                Price = 1.2m,
                Quantity = 10,
                Id = 1
            };

            var part2 = new Part
            {
                ImageUrl = "dsa",
                Name = "spas",
                Price = 11.2m,
                Quantity = 110,
                Id = 2
            };
            db.AddRange(part1, part2);
            db.SaveChanges();
            return db;
        }
    }
}
