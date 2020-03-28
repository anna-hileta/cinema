using Microsoft.AspNetCore.Mvc;


namespace Cinema.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
