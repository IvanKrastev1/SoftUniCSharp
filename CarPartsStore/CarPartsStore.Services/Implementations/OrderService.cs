using AutoMapper.QueryableExtensions;
using CarPartsStore.Data;
using CarPartsStore.Services.Interfaces;
using CarPartsStore.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.Services.Implementations
{
    public class OrderService : IOrderService

    {
        private readonly CarPartsStoreDbContext db;

        public OrderService(CarPartsStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AllOrdersListingModel>> All()
        {
            return await this
                .db
                .Orders
                .Where(a => a.IsDelivered == false)
                .Select(x => new AllOrdersListingModel
                {
                    Id = x.Id,
                    User = this.db.Users.SingleOrDefault(a => a.Id == x.UserId),
                    Part = this.db.Parts.SingleOrDefault(a => a.Id == x.PartId),
                    Address = x.Address,
                    Quantity = x.Quantity,
                    TotalPrice = x.TotalPrice
                }).ToListAsync();
        }

        public async Task Deliver(int id)
        {
            var order = await this
                .db
                .Orders
                .SingleOrDefaultAsync(u => u.Id == id);

            order.IsDelivered = true;

            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllOrdersListingModel>> MyOrders(string userName)
        {
            var user = await this.db.Users.SingleOrDefaultAsync(x => x.UserName == userName);

            return await this.db
                 .Orders
                 .Where(x => x.UserId == user.Id)
                 .ProjectTo<AllOrdersListingModel>()
                 .ToListAsync();

        }
    }
}
