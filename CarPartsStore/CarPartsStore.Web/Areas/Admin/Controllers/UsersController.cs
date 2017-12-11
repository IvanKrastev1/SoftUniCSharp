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
        private readonly IAdminUserServices service;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<User> userManager;

        public UsersController(IAdminUserServices service, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.service = service;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult All()
        {
            var result = this.service.All(this.User.Identity.Name);

            return this.View(result);
        }

        public IActionResult Delete(string id)
        {
            this.service.Delete(id);
            this.TempData["SuccessDelete"] = "Deleted successfully!";
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Edit(string id)
        {
            var result = this.service.UserById(id);

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(AdminUserEditModel user)
        {
            this.service.EditUser(user.Id, user.Email, user.FirstName, user.LastName);
            return this.RedirectToAction(nameof(All));
        }

        
        public async Task<IActionResult> AddToRole( string userId,string role)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(role);
            var user = await this.userManager.FindByIdAsync(userId);
            var userExists = user != null;
            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
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
