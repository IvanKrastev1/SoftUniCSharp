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
    public class MessageService : IMessageService
    {
        private readonly CarPartsStoreDbContext db;

        public MessageService(CarPartsStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminAllMessageListingModel>> All()
        {
            return await this
               .db
               .Messages
               .Select(x => new AdminAllMessageListingModel
               {
                   Id = x.Id,
                   Description = x.Description,
                   User = this.db.Users.SingleOrDefault(a => a.Id == x.UserId)
               }).ToListAsync();

            
        }

        public async Task AddMessage(string description, string userId)
        {
            var message = new Message()
            {
                Description = description,
                UserId = userId
            };

            db.Messages.Add(message);
            await db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var message = await this
                .db
                .Messages
                .SingleOrDefaultAsync(u => u.Id == id);
            db.Remove(message);
           await db.SaveChangesAsync();
        }
    }
}
