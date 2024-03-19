using crudemvccore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace crudemvccore.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            return View();
        }
    }
}
