using _01._07._21_EXAM_Internet_Shop.Models;
using _01._07._21_EXAM_Online_Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Controllers
{
    [Route("cart")]
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
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == HttpContext.User.Identity.Name);
            var cart = await _context.Carts.Include(c => c.Products).FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart != null)
            {
                List<Product> products = new();

                foreach (var item in cart.CartProduct)
                {
                    products.Add(item.Product);
                }

                return View(products);
            }

            Cart tempCart = new();

            return View(tempCart.Products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == HttpContext.User.Identity.Name);
            var existedCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == currentUser.Id);
            //var guid = Guid.NewGuid().ToString();

            if (existedCart == null)
            {
                Cart cart = new();
                cart.User = currentUser;
                _context.Carts.Add(cart);
                _context.SaveChanges();

                cart.Products.Add(product);
            }
            else
            {
                currentUser.Cart.Products.Add(product);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("GetProducts", "Cart");
        }

        [Route("emptycart")]
        [HttpGet]
        public async Task<IActionResult> EmptyCart()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == HttpContext.User.Identity.Name);
            var cart = await _context.Carts.Include(c => c.Products).FirstOrDefaultAsync(c => c.UserId == user.Id);

            cart.CartProduct.Clear();

            await _context.SaveChangesAsync();

            return RedirectToAction("GetProducts", "Cart");
        }

        [Route("deleteitem")]
        [HttpPost]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == HttpContext.User.Identity.Name);
            var cart = await _context.Carts.Include(c => c.Products).FirstOrDefaultAsync(c => c.UserId == user.Id);
            var product = cart.CartProduct.FirstOrDefault(p => p.ProductId == id);

            if (product != null)
            {
                cart.CartProduct.Remove(product);

                await _context.SaveChangesAsync();

                return RedirectToAction("GetProducts", "Cart");
            }

            return RedirectToAction("GetProducts", "Cart");
        }

        [Route("checkout")]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {


            return View();
        }
    }
}
