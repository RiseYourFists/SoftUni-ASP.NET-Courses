using Microsoft.AspNetCore.Mvc;

namespace WebShop.App.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.Title = "Login";

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Title = "Create account";
            return View();
        }

        public async Task<IActionResult> Register(string? returnUrl = null)
        {
            return View();
        }

        public IActionResult LogOut(string? returnUrl = null)
        {
            return View();
        }
    }
}
