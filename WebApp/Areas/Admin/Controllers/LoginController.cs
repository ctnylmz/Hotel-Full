using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("Login")]
        public IActionResult Index()
        {
            if (!HttpContext.User.Identity!.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Index", "Admin");
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Mail);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Password is incorrect");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "User not found");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "There is a problem in the system");
            }

            return View(model);
        }
    }
}
