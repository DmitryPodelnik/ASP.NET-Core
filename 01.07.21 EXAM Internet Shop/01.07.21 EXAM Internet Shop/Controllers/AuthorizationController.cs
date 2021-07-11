using System;
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

namespace _01._07._21_EXAM_Internet_Shop.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly OnlineStoreDbContext _context;
        //private readonly ILogger _logger;
        private readonly ILogger _logger = Log.CreateLogger<AuthorizationController>();
        private SHA256Managed sha256 = new();

        public AuthorizationController(OnlineStoreDbContext context)
        {
            _context = context;
        }

        // GET: Authorization
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Authorization/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Authorization/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authorization/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser([Bind("Id,Username,Password,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password)));

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("AllProducts", "Products");
            }
            return View(user);
        }

        // GET: Authorization/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Authorization/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Email")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Authorization/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Authorization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public async Task<ActionResult> SigningIn(string username)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                
            }

            return View();
        }
    }
}
