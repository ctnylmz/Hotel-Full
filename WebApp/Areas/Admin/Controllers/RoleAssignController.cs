using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using WebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleAssignController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleAssignController(IHttpClientFactory httpClientFactory, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleId = item.Id;
                model.UserId = id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(model);
            }
          
            return View(roleAssignViewModels);
        }


        [HttpPost]
        public async Task<IActionResult> Update(List<RoleAssignViewModel> roleAssignViewModel)
        {
            string id = RouteData.Values["id"]?.ToString();
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            foreach (var item in roleAssignViewModel)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Index");
        }

    }
}
