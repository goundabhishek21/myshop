using Microsoft.AspNetCore.Mvc;

namespace crudemvccore.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult OrderSummary()
        {
            return View();
        }
    }
}
