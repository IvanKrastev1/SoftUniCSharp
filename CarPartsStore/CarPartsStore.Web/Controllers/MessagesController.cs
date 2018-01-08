using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarPartsStore.Web.Models.Messages;
using CarPartsStore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using CarPartsStore.Data.Models;

namespace CarPartsStore.Web.Controllers
{
    public class MessagesController : Controller
    {

        public readonly IMessageService service;
        private readonly UserManager<User> userManager;
        public MessagesController(IMessageService service,UserManager<User> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(MessageFormViewModel model)
        {
            var senderId = this.userManager.GetUserId(this.User);
            await this.service.AddMessage(model.Description, senderId);
            return RedirectToAction(nameof(HomeController.Index), WebConstants.HomeControllerName);

        }
    }
}