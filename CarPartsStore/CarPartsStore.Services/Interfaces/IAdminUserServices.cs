using CarPartsStore.Services.Models;
using System.Collections;
using System.Collections.Generic;

namespace CarPartsStore.Services.Interfaces
{
    public interface IAdminUserServices
    {
        IEnumerable<AdminUserListingModel> All(string currentAdmin);
        void Delete(string id);
        AdminUserEditModel UserById(string id);
        void EditUser(string id, string email, string firstName, string lastName);
    }


}
