using E_State.Entities.Entities;
using E_State.UI.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_State.UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminUserManagementController : Controller
    {
        private UserManager<UserAdmin> _userManager;
        private SignInManager<UserAdmin> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AdminUserManagementController(UserManager<UserAdmin> userManager, SignInManager<UserAdmin> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var list = _userManager.Users.Where(x => x.Status == true).ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View(new RegisterModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            UserAdmin user = new UserAdmin()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                Status = true,

            };
            IdentityRole role = new IdentityRole()
            {
                Name = "User"
            };

            await _roleManager.CreateAsync(role);

            var result = await _userManager.CreateAsync(user, model.Password);

            var result1 = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded || result1.Succeeded)
            {
                return RedirectToAction("Index");

            }
            else
            {
                result.Errors.ToList().ForEach(x => ModelState.AddModelError("", x.Description));
                return View(model);
            }
        }

        public async Task<IActionResult> UserDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.Status = false;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("DeleteUserList");
        }


        public IActionResult DeleteUserList()
        {
            var list = _userManager.Users.Where(x => x.Status == false).ToList();
            return View(list);
        }

        public async Task<IActionResult> UsersActive(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.Status = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
    }
}
