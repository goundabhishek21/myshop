using crudemvccore.Data;
using crudemvccore.Models;
using crudemvccore.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace crudemvccore.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        public CheckoutController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var viewmodel = new CheckoutViewModel()
            {
                Carts = await _context.Carts.Where(x => x.UserId == currentUser.Id).Include(c => c.Product).ToListAsync()
            };

            return View(viewmodel);

        }
        [HttpPost]
        public async Task<IActionResult> Index(CheckoutViewModel model)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    UserId = currentUser.Id,
                    Name = model.Name,
                    Address = model.Address,
                    Country = model.Country,
                    Email = model.Email,
                    Contact = model.Contact,
                    PinCode = model.PinCode,
                    State = model.State,
                };
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ThankYou));


            }

            model.Carts = await _context.Carts.Where(x => x.UserId == currentUser.Id).Include(c => c.Product).ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> ThankYou()
        {
            return View();
        }



    }


}

