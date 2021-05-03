using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products_second_02._05._21.Models;

namespace Products_second_02._05._21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Product(string product)
        {
            switch (product)
            {
                case "1":

                    ViewData["ProductName"] = "Laptop 1";
                    ViewData["ProductImage"] = "1.jpg";
                    ViewData["ProductInfo"] = "Высокочастотный процессор\nНовейший процессор Intel Core 10 - го поколения обеспечивает прирост производительности по сравнению со своим предшественником.";
                    ViewData["ProductPrice"] = 900;

                    break;

                case "2":

                    ViewData["ProductName"] = "Laptop 2";
                    ViewData["ProductImage"] = "2.jpg";
                    ViewData["ProductInfo"] = "Высокочастотный процессор\nНовейший процессор Intel Core 10 - го поколения обеспечивает прирост производительности по сравнению со своим предшественником.";
                    ViewData["ProductPrice"] = 1900;

                    break;

                case "3":

                    ViewData["ProductName"] = "Laptop 3";
                    ViewData["ProductImage"] = "3.jpg";
                    ViewData["ProductInfo"] = "Высокочастотный процессор\nНовейший процессор Intel Core 10 - го поколения обеспечивает прирост производительности по сравнению со своим предшественником.";
                    ViewData["ProductPrice"] = 1500;

                    break;

                case "4":

                    ViewData["ProductName"] = "Laptop 4";
                    ViewData["ProductImage"] = "4.jpg";
                    ViewData["ProductInfo"] = "Высокочастотный процессор\nНовейший процессор Intel Core 10 - го поколения обеспечивает прирост производительности по сравнению со своим предшественником.";
                    ViewData["ProductPrice"] = 1000;

                    break;

                case "5":

                    ViewData["ProductName"] = "Laptop 5";
                    ViewData["ProductImage"] = "5.jpg";
                    ViewData["ProductInfo"] = "Высокочастотный процессор\nНовейший процессор Intel Core 10 - го поколения обеспечивает прирост производительности по сравнению со своим предшественником.";
                    ViewData["ProductPrice"] = 1200;

                    break;

                case "6":

                    ViewData["ProductName"] = "Laptop 6";
                    ViewData["ProductImage"] = "6.jpg";
                    ViewData["ProductInfo"] = "Высокочастотный процессор\nНовейший процессор Intel Core 10 - го поколения обеспечивает прирост производительности по сравнению со своим предшественником.";
                    ViewData["ProductPrice"] = 1300;

                    break;
            }


            return View();
        }
        public IActionResult Contacts()
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
