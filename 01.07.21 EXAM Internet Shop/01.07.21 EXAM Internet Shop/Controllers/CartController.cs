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

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == HttpContext.User.Identity.Name);
            var guid = Guid.NewGuid().ToString();

            //if (currentUser.Cart == null)
            //{
                //Cart cart = new();
                //cart.Products.Add(product);
                currentUser.Cart.Products.Add(product);
                //var existCart = _context.Carts.Add(cart);

                //currentUser.CartId = existCart.Entity.Id;
            //}
            //else
            //{
                //currentUser.Cart.Products.Add(product);
            //}

            _context.Users.Update(currentUser);
            await _context.SaveChangesAsync();

            //if (Request.Cookies["guid"] == null)
            //{
            //Cart newCart = new();
            //newCart.Products.Add(product);
            //newCart.tempId = guid;
            //Response.Cookies.Append("guid", guid);

            //await _context.Carts.AddAsync(newCart);

            //var cartd = await _context.Carts.FirstOrDefaultAsync(c => c.tempId == Request.Cookies["guid"] && c.tempId != null);

            return RedirectToAction("GetProducts", "Cart");
            //}
     
            //var cart = await _context.Carts.FirstOrDefaultAsync(c => c.tempId == Request.Cookies["guid"]);
            //cart.Products.Add(product);

            //_context.Carts.Update(cart);
            //await _context.SaveChangesAsync();

            //return RedirectToAction("GetProducts", "Cart", cart);
        }
    }
}
