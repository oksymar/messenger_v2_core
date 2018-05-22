using Microsoft.AspNetCore.Mvc;

namespace messenger_v2_core.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}