using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _01._07._21_EXAM_Internet_Shop.Models;
using _01._07._21_EXAM_Online_Store;

namespace _01._07._21_EXAM_Internet_Shop.Controllers
{
    public class UsersController : Controller
    {
        private readonly OnlineStoreDbContext _context;

        public UsersController(OnlineStoreDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> MyAccount()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == HttpContext.User.Identity.Name);

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var orders = await _context.Orders
                                    .Join(_context.Users,
                                          o => o.UserId,
                                          u => u.Id,
                                          (o, u) => new
                                          {
                                              Id = o.Id,
                                              Number = o.Number,
                                              Address = o.Address,
                                              NoteContent = o.NoteContent,
                                              Customer = o.Customer,
                                              OrderDate = o.OrderDate,
                                              Products = o.Products,
                                              User = u.Username
                                          }).ToListAsync();

            return View(orders);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
