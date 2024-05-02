using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using WebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<IdentityUser> _userManager;

        public SettingsController(IHttpClientFactory httpClientFactory, UserManager<IdentityUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            SettingUserViewModel userEditViewModel = new SettingUserViewModel();
            userEditViewModel.Username = user.UserName;
            userEditViewModel.Email = user.Email;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(SettingUserViewModel settingUserViewModel)
        {
            if (settingUserViewModel.Password == settingUserViewModel.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Email = settingUserViewModel.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, settingUserViewModel.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

    }
}
