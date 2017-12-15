using CarPartsStore.Data.Enums;
using CarPartsStore.Services.Models;
using System;
using System.Collections.Generic;

namespace CarPartsStore.Services.Interfaces
{
    public interface IAdminCarService
    {
        IEnumerable<AdminCarListingModel> All();

        void Delete(int id);

        AdminCarEditModel CarById(int id);

        void EditCar(int id, string make, string model, string year, FuelType fuel, string motor);

        void AddCar(string make, string model, string year, FuelType fuel, string motor);
    }
}
