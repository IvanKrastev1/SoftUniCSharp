using CarPartsStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPartsStore.Services.Interfaces
{
     public interface IOrderService
    {
        Task<IEnumerable<AllOrdersListingModel>> All();

        Task<IEnumerable<AllOrdersListingModel>> MyOrders(string userName);

        Task Deliver(int id);
    }
}
