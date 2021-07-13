using _01._07._21_EXAM_Online_Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly OnlineStoreDbContext _context;

        public AdminController(OnlineStoreDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return View(await _context.Categories.ToListAsync());
        }
    }
}
