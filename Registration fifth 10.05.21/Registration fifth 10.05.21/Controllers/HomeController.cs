using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Registration_fifth_10._05._21.Models;

namespace Registration_fifth_10._05._21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RegInfo _regInfo = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public async Task<ActionResult> SigningIn(string username)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("logs.txt", false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync($"User {username} tried to sign into the system.");
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }

            return View();
        }
        public async Task<ActionResult> Registration(string username, string password, string email)
        {
            using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                _regInfo.Username = username;
                _regInfo.Password = password;
                _regInfo.Email = email;
                await JsonSerializer.SerializeAsync<RegInfo>(fs, _regInfo, options);
                //Console.WriteLine("Data has been saved to file");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
