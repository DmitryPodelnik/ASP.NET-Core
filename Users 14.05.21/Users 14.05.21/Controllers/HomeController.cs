using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Users_14._05._21.Models;

namespace Users_14._05._21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var parameters = new List<SqlParameter>();
                        parameters.Add(new("@username", user.Username));
                        parameters.Add(new("@password", user.Password));
                        parameters.Add(new("@email", user.Email));

                        await db.Users.FromSqlRaw("AddUser @username, @password, @email", parameters.ToArray()).ToListAsync();
                    }
                    return View("RegDone", user);
                }
                catch (InvalidOperationException)
                {
                    return View("RegDone", user);
                }
            }
            else
                return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
