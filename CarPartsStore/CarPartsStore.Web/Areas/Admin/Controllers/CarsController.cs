using CarPartsStore.Services.Interfaces;
using CarPartsStore.Services.Models;
using CarPartsStore.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarPartsStore.Web.Areas.Admin.Controllers
{
    public class CarsController : BaseAdminController
    {
        private readonly ICarService service;

        public CarsController(ICarService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var result = await this.service.All();
            return View(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.Delete(id);
            this.TempData[WebConstants.TempDataSuccessDelete] = WebConstants.DeletedSuccessfullyMessage;
            return this.RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await this.service.CarById(id);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminCarEditModel car)
        {
            await this.service.EditCar(car.Id, car.Make, car.Model, car.Year, car.Fuel, car.Motor);
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdminAddCarFormModel car)
        {
            await this.service.AddCar(car.Make, car.Model, car.Year, car.Fuel, car.Motor);
            return this.RedirectToAction(nameof(All));
        }
    }
}
