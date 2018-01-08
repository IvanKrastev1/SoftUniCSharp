using CarPartsStore.Data.Enums;
using CarPartsStore.Services.Interfaces;
using CarPartsStore.Services.Models;
using CarPartsStore.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarPartsStore.Web.Areas.Admin.Controllers
{
    public class PartsController : BaseAdminController
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
            var result = await this.service.All();

            return  View(result);
        }

        public async Task<IActionResult> Add()
        {
            var allcars = await this.carService.All();
            AdminAddPartFormModel model = new AdminAddPartFormModel
            {
                Cars = allcars
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdminAddPartFormModel part)
        {
            await this.service.AddPart(part.Name, part.Price, part.Quantity, part.CarId,part.ImageUrl);
            return this.RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.Delete(id);
            this.TempData[WebConstants.TempDataSuccessDelete] = WebConstants.DeletedSuccessfullyMessage;
            return this.RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id, string name, decimal price, int quantity,string imageUrl)
        {
            var result =  await this.service.PartById(id);
            var allcars =await  this.carService.All();

            AdminPartEditModel model = new AdminPartEditModel
            {
                Name = result.Name,
                Price = result.Price,
                Quantity = result.Quantity,
                Cars = allcars,
                ImageUrl = result.ImageUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminAddPartFormModel part)
        {
            await this.service.EditPart(part.Id, part.Name, part.Price, part.Quantity, part.CarId,part.ImageUrl);
            return this.RedirectToAction(nameof(All));
        }
    }
}
