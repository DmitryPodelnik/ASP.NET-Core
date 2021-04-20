using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string firstNumber, string secondNumber, string calculate)
        {
            switch (calculate)
            {
                case "+":

                    ViewData["Result"] = Int32.Parse(firstNumber) + Int32.Parse(secondNumber);

                    break;

                case "-":

                    ViewData["Result"] = Int32.Parse(firstNumber) - Int32.Parse(secondNumber);

                    break;

                case "*":

                    ViewData["Result"] = Int32.Parse(firstNumber) * Int32.Parse(secondNumber);

                    break;

                case "/":

                    if (Int32.Parse(secondNumber) != 0)
                    {
                        ViewData["Result"] = Int32.Parse(firstNumber) / Int32.Parse(secondNumber);
                    }
                    else
                    {
                        ViewData["Result"] = "Error";
                    }

                    break;
            }

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
