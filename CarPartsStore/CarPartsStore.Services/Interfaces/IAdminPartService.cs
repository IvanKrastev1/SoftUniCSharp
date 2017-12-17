using CarPartsStore.Services.Models;
using System.Collections.Generic;

namespace CarPartsStore.Services.Interfaces
{
    public interface IAdminPartService
    {
        IEnumerable<AdminAllPartsListingModel> All();

        void AddPart(string name, decimal price, int quantity, int carId);

        void Delete(int id);

        AdminPartEditModel PartById(int id);

        void EditPart(int id, string name, decimal price, int quantity, int carId);
    }
}
