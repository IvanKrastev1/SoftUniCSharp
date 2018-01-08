using CarPartsStore.Data.Enums;
using CarPartsStore.Services.Interfaces;
using CarPartsStore.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarPartsStore.Web.Areas.Supplier.Controllers
{
    public class PartsController : BaseSupplierController
    {
        private readonly IPartService service;
        private readonly ICarService carService;

        public PartsController(IPartService service, ICarService carService)
        {
            this.service = service;
            this.carService = carService;
        }

        public async Task<IActionResult> All()
        {
            var result = await service.AllSupplier();

            return View(result);
        }

        
    }
}
