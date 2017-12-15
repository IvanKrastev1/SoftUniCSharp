using CarPartsStore.Services.Interfaces;
using CarPartsStore.Services.Models;
using CarPartsStore.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPartsStore.Web.Areas.Admin.Controllers
{
    public class CarsController : BaseAdminController
    {
        private readonly IAdminCarService service;

        public CarsController(IAdminCarService service)
        {
            this.service = service;
        }

        public IActionResult All()
        {
            var result = service.All();
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            this.service.Delete(id);
            this.TempData["SuccessDelete"] = "Deleted successfully!";
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var result = this.service.CarById(id);

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(AdminCarEditModel car)
        {
            this.service.EditCar(car.Id, car.Make, car.Model, car.Year, car.Fuel, car.Motor);
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminAddCarFormModel car)
        {
            this.service.AddCar(car.Make, car.Model, car.Year, car.Fuel, car.Motor);
            return this.RedirectToAction(nameof(All));
        }
    }
}
