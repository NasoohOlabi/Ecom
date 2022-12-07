using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DB.Models;
using Ecom.Models;
using System.Xml.Linq;

namespace Ecom.Controllers
{
    public class ProductController : Controller
    {
        private readonly EComContext _context;

        public ProductController(EComContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var detailsViewModels =
                from p in (await _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Seller).ToListAsync())
                select new ProductDetailsViewModel(p);

            return View(detailsViewModels);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(new ProductDetailsViewModel(product));
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["SellerId"] = new SelectList(_context.Users, "Id", "BirthDate");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductEditViewModel model)
        {
            var currentProduct = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId,
                SellerId = model.SellerId,
                RatingSum = 0,
                RatingCount = 0,
                OrderCount = 0,
                Discount = model.Discount
            };

            if (ModelState.IsValid)
            {
                _context.Add(currentProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", currentProduct.CategoryId);
            ViewData["SellerId"] = new SelectList(_context.Users, "Id", "BirthDate", currentProduct.SellerId);
            return View(currentProduct);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["SellerId"] = new SelectList(_context.Users, "Id", "BirthDate", product.SellerId);
            return View(new ProductEditViewModel(product));
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            var currentProduct = await _context.Products
                .FirstOrDefaultAsync(p => model.Id == p.Id);
            if (currentProduct == null)
            {
                return NotFound();
            }
            // editable fields
            currentProduct.Name = model.Name;
            currentProduct.Price = model.Price;
            if (model.Seller?.Id != null)
                currentProduct.SellerId = model.Seller.Id;
            currentProduct.Discount = model.Discount;
            currentProduct.Description = model.Description;
            if (model.Category?.Id != null)
                currentProduct.CategoryId = model.Category.Id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(currentProduct.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", currentProduct.CategoryId);
            ViewData["SellerId"] = new SelectList(_context.Users, "Id", "BirthDate", currentProduct.SellerId);
            return View(currentProduct);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'EComContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
