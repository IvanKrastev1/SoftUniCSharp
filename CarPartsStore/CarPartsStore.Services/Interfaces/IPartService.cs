using CarPartsStore.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarPartsStore.Services.Interfaces
{
    public interface IPartService
    {
        Task<IEnumerable<AllPartsListingModel>> All();

        Task<IEnumerable<AllPartsListingModel>> AllSupplier();

        Task AddPart(string name, decimal price, int quantity, int carId, string imageUrl);

        Task Delete(int id);

        Task<AdminPartEditModel> PartById(int id);

        Task EditPart(int id, string name, decimal price, int quantity, int carId, string imageUrl);

        Task<bool> OrderPart(string user, int partId,string address,int quantity);

        Task<PartOrderViewModel> GetOrderPart(int partId);
    }
}
