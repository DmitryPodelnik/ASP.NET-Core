﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _01._07._21_EXAM_Internet_Shop.Models;
using _01._07._21_EXAM_Online_Store;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using _01._07._21_EXAM_Internet_Shop.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace _01._07._21_EXAM_Internet_Shop.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly OnlineStoreDbContext _context;
        //private readonly ILogger _logger;
        private readonly ILogger _logger = Log.CreateLogger<AuthorizationController>();
        private SHA256Managed _sha256 = new();

        public AuthorizationController(OnlineStoreDbContext context)
        {
            _context = context;
        }

        // GET: Authorization
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        // POST: Authorization/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser([Bind("Id,Username,FirstName,LastName,Password,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username || u.Email == user.Email);

                if (existedUser == null)
                {
                    user.Password = Convert.ToBase64String(_sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password)));
                    user.RoleId = 1;
                     
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("AllProducts", "Products");
                }

                ModelState.AddModelError("", "Email  or username is already exists!");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = Convert.ToBase64String(
                    _sha256.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));

                User user = _context.Users
                    .Include(user => user.Role)
                    .FirstOrDefault(u => u.Email == model.Email && u.Password == passwordHash);

                if (user != null)
                {
                    await Authenticate(user);
                    return RedirectToAction("AllProducts", "Products");
                }

                ModelState.AddModelError("", "Invalid login or password");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("AllProducts", "Products");
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name),
            };

            ClaimsIdentity identity = new(
                claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
             );

            ClaimsPrincipal principal = new(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
