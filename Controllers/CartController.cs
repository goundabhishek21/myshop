using crudemvccore.Data;
using crudemvccore.Data.Migrations;
using crudemvccore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace crudemvccore.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Carts.Include(m => m.Product).Include(x => x.User);
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
            var cart = new Cart()
            {
                ProductId = (int)productId,

                Quantity = quantity
            };
            _context.Add(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
     
        public async Task<IActionResult> Delete(int? id)
        {

           
            var cart = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (cart != null)
            {
                _context.Remove(cart);
                await _context.SaveChangesAsync();
            }
           
          
            return RedirectToAction("Index");

        }
    }
    }
