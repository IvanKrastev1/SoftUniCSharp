using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarPartsStore.Services.Interfaces;
using CarPartsStore.Services.Models;

namespace CarPartsStore.Web.Areas.Admin.Controllers
{
    public class OrdersController : BaseAdminController
    {

        private readonly IOrderService service;
        public OrdersController(IOrderService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> All()
        {
            var result = await this.service.All();

            return View(result);
        }

        public async Task<IActionResult> Deliver(int Id)
        {
            await this.service.Deliver(Id);
            return this.RedirectToAction(nameof(All));
        }
    }
}