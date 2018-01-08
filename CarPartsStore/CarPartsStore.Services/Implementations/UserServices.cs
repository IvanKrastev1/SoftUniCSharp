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
    public class UserServices : IUserServices
    {
        private readonly CarPartsStoreDbContext db;

        public UserServices(CarPartsStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingModel>> All(string currentAdmin)
        {
            var users =await this
                .db
                .Users
                .Where(x => x.UserName != currentAdmin)
                .ProjectTo<AdminUserListingModel>()
                .ToListAsync();
            return  users;
        }

        public async Task Delete(string id)
        {
            var user = await this
                .db
                .Users
                .SingleOrDefaultAsync(u => u.Id == id);
            this.db.Remove(user);
            await this.db.SaveChangesAsync();
        }

        public async Task<AdminUserEditModel> UserById(string id)
        {
          
                var user =await this.db
                .Users
                .Where(i => i.Id == id)
                .ProjectTo<AdminUserEditModel>()
                .SingleOrDefaultAsync();
                return user;
            
        }

        public async Task EditUser(string id, string email, string firstName, string lastName)
        {
            if (await IsValidUser(id))
            {
                var user =await this.db
               .Users
               .SingleOrDefaultAsync(i => i.Id == id);

                user.Email = email;
                user.FirstName = firstName;
                user.LastName = lastName;

                await this.db.SaveChangesAsync();
            }
        }

        private async Task<bool> IsValidUser(string id)
        {
            return await db.Users.AnyAsync(k => k.Id == id);
        }
    }
}
