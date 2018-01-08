using CarPartsStore.Services.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarPartsStore.Services.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<AdminUserListingModel>> All(string currentAdmin);
        Task Delete(string id);
        Task<AdminUserEditModel> UserById(string id);
        Task EditUser(string id, string email, string firstName, string lastName);
    }


}
