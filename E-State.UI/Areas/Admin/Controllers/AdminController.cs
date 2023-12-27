using E_State.Entities.Entities;
using E_State.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_State.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private UserManager<UserAdmin> _userManager;
        private SignInManager<UserAdmin> _signInManager;

        public AdminController(UserManager<UserAdmin> userManager, SignInManager<UserAdmin> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError(" ", "Kullanıcı bilgileri hatalı");
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                HttpContext.Session.SetString("Id", user.Id);
                HttpContext.Session.SetString("FullName", user.FullName);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Remove("FullName");
            return RedirectToAction("Login");
        }
    }
}
