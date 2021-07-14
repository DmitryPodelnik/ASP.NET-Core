using _01._07._21_EXAM_Internet_Shop.Models;
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
    [Authorize(Roles = "admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly OnlineStoreDbContext _context;

        public AdminController(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("getcategories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return View(await _context.Categories.ToListAsync());
        }

        [Route("getproducts")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return View(await _context.Products.ToListAsync());
        }

        [Route("getusers")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return View(await _context.Users.ToListAsync());
        }

        [Route("getcurrentorders")]
        [HttpGet]
        public async Task<IActionResult> GetCurrentOrders()
        {
            return View(await _context.Users.ToListAsync());
        }

        [Route("getordershistory")]
        [HttpGet]
        public async Task<IActionResult> GetOrdersHistory()
        {
            return View(await _context.Users.ToListAsync());
        }

        [Route("addcategory")]
        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }

        [Route("addcategory")]
        [HttpPost]
        public async Task<IActionResult> AddCategory([Bind("Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                var existedCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);

                if (existedCategory == null)
                {
                    await _context.Categories.AddAsync(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("GetCategories", "Admin");
                }

                ModelState.AddModelError("", "Email  or username is already exists!");
            }

            return View(category);
        }
    }
}
