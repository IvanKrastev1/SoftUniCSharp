using CarPartsStore.Data.Enums;
using CarPartsStore.Services.Interfaces;
using CarPartsStore.Services.Models;
using CarPartsStore.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPartsStore.Web.Areas.Admin.Controllers
{
    public class PartsController : BaseAdminController
    {
        private readonly IAdminPartService service;
        private readonly IAdminCarService carService;

        public PartsController(IAdminPartService service, IAdminCarService carService)
        {
            this.service = service;
            this.carService = carService;
        }

        public IActionResult All()
        {
            var result = service.All();

            return View(result);
        }

        public IActionResult Add()
        {
            var allcars = this.carService.All();
            AdminAddPartFormModel model = new AdminAddPartFormModel
            {
                Cars = allcars
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AdminAddPartFormModel part)
        {
            this.service.AddPart(part.Name, part.Price, part.Quantity, part.CarId);
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            this.service.Delete(id);
            this.TempData["SuccessDelete"] = "Deleted successfully!";
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id, string name, decimal price, int quantity)
        {
            var result = this.service.PartById(id);
            var allcars = this.carService.All();
            AdminPartEditModel model = new AdminPartEditModel
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Cars = allcars
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AdminAddPartFormModel part)
        {
            this.service.EditPart(part.Id, part.Name, part.Price, part.Quantity, part.CarId);
            return this.RedirectToAction(nameof(All));
        }
    }
}
