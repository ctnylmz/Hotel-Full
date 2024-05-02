using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using WebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(IHttpClientFactory httpClientFactory, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var result = _roleManager.Roles.ToList();

            return View(result);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();  
        }


        public async Task<IActionResult> Delete(string id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id,string Name)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            value.Name = Name;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }


    }
}
