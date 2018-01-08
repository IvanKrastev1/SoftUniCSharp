namespace CarPartsStore.Web.Areas.Admin.Controllers
{
    using CarPartsStore.Data.Models;
    using CarPartsStore.Services.Interfaces;
    using CarPartsStore.Services.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class UsersController : BaseAdminController
    {
        private readonly IUserServices service;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<User> userManager;

        public UsersController(IUserServices service, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.service = service;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> All()
        {
            var result = await this.service.All(this.User.Identity.Name);

            return this.View(result);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.service.Delete(id);
            this.TempData[WebConstants.TempDataSuccessDelete] = WebConstants.DeletedSuccessfullyMessage;
            return this.RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var result = await this.service.UserById(id);

            return View(result);
        }

        [HttpPost]
        public async  Task<IActionResult> Edit(AdminUserEditModel user)
        {
            await this.service.EditUser(user.Id, user.Email, user.FirstName, user.LastName);
            return this.RedirectToAction(nameof(All));
        }

        
        public async Task<IActionResult> AddToRole( string userId,string role)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(role);
            var user = await this.userManager.FindByIdAsync(userId);
            var userExists = user != null;
            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, WebConstants.InvalidDetails);
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(All));
            }

            await this.userManager.AddToRoleAsync(user, role);

            return this.RedirectToAction(nameof(All));
        }
    }
}
