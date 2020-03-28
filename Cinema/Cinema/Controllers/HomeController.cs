using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Cinema.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
    }
}
