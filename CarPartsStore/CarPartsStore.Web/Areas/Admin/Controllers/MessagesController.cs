using CarPartsStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarPartsStore.Web.Areas.Admin.Controllers
{
    public class MessagesController : BaseAdminController
    {
        private readonly IMessageService service;

        public MessagesController(IMessageService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var result =await service.All();
            return  View(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.Delete(id);
            this.TempData[WebConstants.TempDataSuccessDelete] = WebConstants.DeletedSuccessfullyMessage;
            return this.RedirectToAction(nameof(All));
        }


    }
}
