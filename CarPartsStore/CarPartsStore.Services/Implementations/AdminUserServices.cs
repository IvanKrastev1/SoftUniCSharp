using AutoMapper.QueryableExtensions;
using CarPartsStore.Data;
using CarPartsStore.Services.Interfaces;
using CarPartsStore.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarPartsStore.Services.Implementations
{
    public class AdminUserServices : IAdminUserServices
    {
        private readonly CarPartsStoreDbContext db;

        public AdminUserServices(CarPartsStoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminUserListingModel> All(string currentAdmin)
        {
            var users = this
                .db
                .Users
                .Where(x => x.UserName != currentAdmin)
                .ProjectTo<AdminUserListingModel>()
                .ToList();
            return users;
        }

        public void Delete(string id)
        {
            var user = this
                .db
                .Users
                .FirstOrDefault(u => u.Id == id);
            db.Remove(user);
            db.SaveChanges();
        }

        public AdminUserEditModel UserById(string id)
        {
          
                var user = db
                .Users
                .Where(i => i.Id == id)
                .ProjectTo<AdminUserEditModel>()
                .FirstOrDefault();
                return user;
            
        }

        public void EditUser(string id, string email, string firstName, string lastName)
        {
            if (IsValidUser(id))
            {
                var user = db
               .Users
               .FirstOrDefault(i => i.Id == id);

                user.Email = email;
                user.FirstName = firstName;
                user.LastName = lastName;

                db.SaveChanges();
            }
        }

        private bool IsValidUser(string id)
        {
            return db.Users.Any(k => k.Id == id);
        }
    }
}
