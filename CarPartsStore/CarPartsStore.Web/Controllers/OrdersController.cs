
namespace CarPartsStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using CarPartsStore.Services.Interfaces;

    public class OrdersController : Controller
    {
        private readonly IOrderService service;
        public OrdersController(IOrderService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var userName = this.User.Identity.Name;

            if (userName == null)
            {
                return this.RedirectToAction(nameof(HomeController.Index));
            }
            var model = await this.service.MyOrders(userName);

            return this.View(model);
        }
    }
}