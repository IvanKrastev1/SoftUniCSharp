using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarPartsStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CarPartsStore.Services.Models;

namespace CarPartsStore.Web.Controllers
{
    public class PartsController : Controller
    {
        private readonly IPartService service;

        public PartsController(IPartService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var model = await this.service.All();

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ConfirmOrder(int partId)
        {
            var result = await this.service.GetOrderPart(partId);

            if (result == null)
            {
                this.TempData[WebConstants.TempDataSorry] = WebConstants.Wrong;
                return this.RedirectToAction(nameof(All));
            }

            return this.View(result);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(PartOrderViewModel partOrder)
        {
           
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(ConfirmOrder), new { partId = partOrder.partId });
            }
            var user = this.User.Identity.Name;
            var result = await this.service.OrderPart(user, partOrder.partId, partOrder.Address, partOrder.Quantity);

            if (result == false)
            {
                this.TempData[WebConstants.TempDataSorry] = WebConstants.Wrong;
            }
            this.TempData[WebConstants.TempDataPurchaseOk] = WebConstants.PurchaseOk;

            return this.RedirectToAction(nameof(All));
        }
    }
}