using AutoMapper.QueryableExtensions;
using CarPartsStore.Data;
using CarPartsStore.Data.Models;
using CarPartsStore.Services.Interfaces;
using CarPartsStore.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarPartsStore.Services.Implementations
{
    public class AdminPartService : IAdminPartService
    {
        private readonly CarPartsStoreDbContext db;

        public AdminPartService(CarPartsStoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminAllPartsListingModel> All()
        {
            var parts = this
                .db
                .Parts
                .Select(x => new AdminAllPartsListingModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Car = this.db.Cars.FirstOrDefault(a => a.Id == x.CarId)
                });

            return parts;
        }

        public void AddPart(string name, decimal price, int quantity, int carId)
        {   
            var part = new Part()
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                CarId = carId
            };

            db.Parts.Add(part);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var part = this
                .db
                .Parts
                .FirstOrDefault(u => u.Id == id);
            db.Remove(part);
            db.SaveChanges();
        }

        public AdminPartEditModel PartById(int id)
        {
            var part = db
            .Parts
            .Where(i => i.Id == id)
            .ProjectTo<AdminPartEditModel>()
            .FirstOrDefault();
            return part;
        }
        
        public void EditPart(int id, string name, decimal price, int quantity, int carId)
        {
            if (IsValidPart(id))
            {
                var part = db
               .Parts
               .FirstOrDefault(i => i.Id == id);

                part.Name = name;
                part.Price = price;
                part.Quantity = quantity;
                part.CarId = carId;

                db.SaveChanges();
            }
        }

        private bool IsValidPart(int id)
        {
            return db.Parts.Any(k => k.Id == id);
        }
    }
}
