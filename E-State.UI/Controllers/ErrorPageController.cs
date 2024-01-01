using Microsoft.AspNetCore.Mvc;

namespace E_State.UI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
