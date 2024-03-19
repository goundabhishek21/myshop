using Microsoft.AspNetCore.Mvc;

namespace crudemvccore.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
