using _01._07._21_EXAM_Internet_Shop.Models;
using _01._07._21_EXAM_Online_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Online_Store.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger _logger = Log.CreateLogger<HomeController>();
        private readonly OnlineStoreDbContext _context;

        public HomeController(OnlineStoreDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();

            return View(categories);
        }

        public ActionResult GetLeftAside()
        {
            return PartialView("LeftAside");
        }

        public IActionResult About()
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
