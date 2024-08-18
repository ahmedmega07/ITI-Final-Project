using ITI_Final_Poject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Final_Poject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult NEW()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NEW(RoleViewModel newRolev)
        {

            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = newRolev.RoleName;
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View(new RoleViewModel());
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }



            }

            return View(newRolev);
        }
    }
}
