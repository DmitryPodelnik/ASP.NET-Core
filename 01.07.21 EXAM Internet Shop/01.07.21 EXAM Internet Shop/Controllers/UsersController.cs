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
            var orders = await _context.Users.FirstOrDefaultAsync(u => u.Username == HttpContext.User.Identity.Name);

            return View(orders);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
