using _01._07._21_EXAM_Internet_Shop.Models;
using _01._07._21_EXAM_Online_Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly OnlineStoreDbContext _context;

        public CartController(OnlineStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {

            //var products = await _context.Carts
            //                             .Join(
            //                                _context.Users,
            //                                c => c.UserId,
            //                                u => u.Id,
            //                                (c, u) => new
            //                                {
            //                                    Id = c.Id,

            //                                }
            //                                )

            var products = await _context.Carts.FirstOrDefaultAsync(c => c.Id == 1);

            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product != null)
            {
                Cart newCart = new();
                newCart.Products.Add(product);

                await _context.Carts.AddAsync(newCart);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("GetProducts", "Cart");
        }
    }
}
