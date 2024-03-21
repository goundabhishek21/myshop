using crudemvccore.Data;
using crudemvccore.Data.Migrations;
using crudemvccore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace crudemvccore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var applicationDbContext = _context.Carts.Where(x => x.UserId == currentUser.Id).Include(c => c.Product).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> AddToCart(int? productId, int quantity = 1)
        {
           
            if (productId == null)
            {
                return NotFound();

            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            var currentUser = await _userManager.GetUserAsync(User);
            var cart = new Cart()
            {
                UserId= currentUser.Id,
                ProductId = (int)productId,

                Quantity = quantity

            };
            _context.Add(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
     
        public async Task<IActionResult> Delete(int? Id)
        {

           
            var cart = await _context.Carts.FirstOrDefaultAsync(m => m.Id == Id);
            if (cart != null)
            {
                _context.Remove(cart);
                await _context.SaveChangesAsync();
            }
           
          
            return RedirectToAction("Index");

        }
    }
    }
