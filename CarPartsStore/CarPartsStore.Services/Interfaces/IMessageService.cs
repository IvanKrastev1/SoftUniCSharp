using CarPartsStore.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarPartsStore.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<AdminAllMessageListingModel>> All();

        Task AddMessage(string description, string userId);

        Task Delete(int id);
    }
}
