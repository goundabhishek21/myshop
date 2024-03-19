using crudemvccore.Data;
using crudemvccore.Models;
using ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using crudemvccore.Data.Migrations;

namespace crudemvccore.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly ApplicationDbContext _context;
       
       

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public async Task<IActionResult> Index()
        {
            var products = await _context.Product.ToListAsync();
            var model = new ProductsDetails
            {
                products = products
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
               //else
            //{
            //    // Add new item to cart
            //    AddtoCarts.Add(new AddtoCarts { Product = product, Quantity = Quantity });
            //}

            if (product == null)
            {
                return NotFound();
            }

            return View(product);

           
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
