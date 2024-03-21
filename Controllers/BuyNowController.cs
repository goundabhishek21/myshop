using crudemvccore.Data;
using crudemvccore.Models;
using crudemvccore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace crudemvccore.Controllers
{
    [Authorize]
    public class BuyNowController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BuyNowController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index(int productId, int Quantity = 1)
        {
            var product = await _context.Product.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var model = new BuyNowViewModel
            {
                product = product,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BuyNowViewModel model, int productId, int Quantity = 1)
        {
            var product = await _context.Product.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);

                var order = new Order
                {
                    UserId = currentUser.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Contact = model.Contact,
                    Address=model.Address,
                    Country=model.Country,
                    State=model.State,
                    PinCode=model.PinCode
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();


                var orderProduct = new Orderproduct()
                {
                    OrderId = order.Id,
                    ProductId = productId,
                    Quantity =Quantity,
                };

                _context.Orderproducts.Add(orderProduct);
                await _context.SaveChangesAsync();




                return RedirectToAction(nameof(ThankYou));
            }

            model.product = product;
            return View(model);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
