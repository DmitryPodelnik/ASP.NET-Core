using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _01._07._21_EXAM_Internet_Shop.Models;
using _01._07._21_EXAM_Online_Store;

namespace _01._07._21_EXAM_Internet_Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly OnlineStoreDbContext _context;

        public ProductsController(OnlineStoreDbContext context)
        {
            _context = context;
        }

        // GET: Products
        //[HttpGet]
        //public async Task<IActionResult> AllProducts()
        //{
        //    return View(await _context.Products.ToListAsync());
        //}

        [Route("")]
        [Route("{skip:int}/{pages:int}")]
        [HttpGet]
        public async Task<IActionResult> AllProducts(int skip = 0, int pages = 1)
        {
            return View(await _context.Products
                .Skip(skip * 12)
                .Take(pages * 12)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Product>> ShowProduct(int product)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == product);

            return View(prod);
        }

        [HttpPost]
        public async Task<IActionResult> SearchProductsByName(string nameProduct)
        {
            var items = await _context.Products
                                    .Where(p => p.Name.Contains(nameProduct))
                                    .ToListAsync();

            return View("AllProducts", items);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int? category)
        {
            var items = await _context.Products
                                    .Where(p => p.CategoryId == category)
                                    .ToListAsync();

            return View("AllProducts", items);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Content,Image,Price,Seller")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Content,Image,Price,Seller")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
