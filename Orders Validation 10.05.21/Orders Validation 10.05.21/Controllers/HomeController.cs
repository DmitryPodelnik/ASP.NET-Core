using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Orders_Validation_10._05._21.Models;

namespace Orders_Validation_10._05._21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Order _orderInfo = new();
        private OrdersRepository _orders = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        // POST: Home/Order
        [HttpPost]
        public IActionResult Order(Order orderInfo)
        {
            if (ModelState.IsValid)
            {
                _orders.Orders.Add(orderInfo);

                return View("OrderDone", orderInfo);
            }    
            else
                return View(orderInfo);
        }
        public IActionResult AllOrders()
        {
            return View(_orders);
        }

        public IActionResult OrderDone()
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
