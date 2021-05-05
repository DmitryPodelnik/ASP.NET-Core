using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products_Partial_Views_04._05._21.Models;

namespace Products_Partial_Views_04._05._21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<Product> _products = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _products.Add(
                new Product(1, "First", 15, DateTime.Now)
                );
            _products.Add(
                new Product(2, "Second", 10, DateTime.Now)
                );
            _products.Add(
                new Product(3, "Third", 5, DateTime.Now)
                );
            _products.Add(
                new Product(4, "Fourth", 25, DateTime.Now)
                );
            _products.Add(
                new Product(5, "Fifth", 35, DateTime.Now)
                );

            return View(_products);
        }

        public IActionResult ProductsTable()
        {
            return PartialView();
        }

        public IActionResult ProductsList()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
