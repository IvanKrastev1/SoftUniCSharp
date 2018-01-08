using CarPartsStore.Data.Enums;
using CarPartsStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarPartsStore.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<AdminCarListingModel>>All();

        Task Delete(int id);

        Task<AdminCarEditModel> CarById(int id);

        Task EditCar(int id, string make, string model, string year, FuelType fuel, string motor);

        Task AddCar(string make, string model, string year, FuelType fuel, string motor);
    }
}
