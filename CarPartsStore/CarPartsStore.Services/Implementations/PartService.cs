using AutoMapper.QueryableExtensions;
using CarPartsStore.Data;
using CarPartsStore.Data.Models;
using CarPartsStore.Services.Interfaces;
using CarPartsStore.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.Services.Implementations
{
    public class PartService : IPartService
    {
        private readonly CarPartsStoreDbContext db;

        public PartService(CarPartsStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AllPartsListingModel>> All()
        {
            return await this
                .db
                .Parts
                .Select(x => new AllPartsListingModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Car = this.db.Cars.SingleOrDefault(a => a.Id == x.CarId),
                    ImageUrl = x.ImageUrl
                }).ToListAsync();
        }

        public async Task<IEnumerable<AllPartsListingModel>> AllSupplier()
        {
            return await this
                .db
                .Parts
                .Where(a => a.Quantity < 5)
                .Select(x => new AllPartsListingModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Car = this.db.Cars.SingleOrDefault(a => a.Id == x.CarId)
                }).ToListAsync();
        }

        public async Task AddPart(string name, decimal price, int quantity, int carId, string imageUrl)
        {
            var part = new Part()
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                CarId = carId,
                ImageUrl = imageUrl
            };

            db.Parts.Add(part);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var part = this
                .db
                .Parts
                .SingleOrDefaultAsync(u => u.Id == id);
            db.Remove(part);
            await db.SaveChangesAsync();
        }

        public async Task<AdminPartEditModel> PartById(int id)
        {
            var part = await db
            .Parts
            .Where(i => i.Id == id)
            .ProjectTo<AdminPartEditModel>()
            .SingleOrDefaultAsync();
            return part;
        }

        public async Task EditPart(int id, string name, decimal price, int quantity, int carId, string ImageUrl)
        {
            if (await IsValidPart(id))
            {
                var part = await this.db
               .Parts
               .SingleOrDefaultAsync(i => i.Id == id);

                part.Name = name;
                part.Price = price;
                part.Quantity = quantity;
                part.CarId = carId;
                part.ImageUrl = ImageUrl;

                await db.SaveChangesAsync();
            }
        }

        private async Task<bool> IsValidPart(int id)
        {
            return await this.db.Parts.AnyAsync(k => k.Id == id);
        }

        public async Task<PartOrderViewModel> GetOrderPart(int partId)
        {
            var part = await db
                      .Parts
                      .Where(i => i.Id == partId)
                      .ProjectTo<PartOrderViewModel>()
                      .SingleOrDefaultAsync();

            var parta = await db
                    .Parts
                    .Where(i => i.Id == partId)
                    .SingleOrDefaultAsync();


            var car = await this.db.Cars.Where(x => x.Id == parta.CarId).SingleOrDefaultAsync();

            part.Car = car.Make + " " + car.Model;

            return part;
        }

        public async Task<bool> OrderPart(string username, int partId, string address, int quantity)
        {
            var user = await this.db
                .Users
                .SingleOrDefaultAsync(x => x.UserName == username);

            var part = await db
                  .Parts
                .SingleOrDefaultAsync(x => x.Id == partId);

            if (part == null)
            {
                return false;
            }

            this.db.Orders.Add(new Order
            {
                Address = address,
                Part = part,
                Quantity = quantity,
                TotalPrice = quantity * part.Price,
                User = user,
                UserId = user.Id,
                PartId = part.Id
            });

            
            part.Quantity -= quantity;
            await this.db.SaveChangesAsync();
            return true;
        }
    }
}
