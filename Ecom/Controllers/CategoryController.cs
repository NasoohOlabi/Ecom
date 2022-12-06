using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DB.Models;
using Ecom.Models;
using System.Collections.Specialized;

namespace Ecom.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EComContext _context;

        public CategoryController(EComContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> l = await _context.Categories.ToListAsync();
            var x = new List<CategoryDetailsViewModel>();
            foreach (Category c in l)
            {
                x.Add(new CategoryDetailsViewModel
                {
                    Name = c.Name,
                    Id = c.Id,
                    ModifiedAt = c.ModifiedAt,
                    CreatedAt = c.CreatedAt,
                });
            }
            return View(x);
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDetailsViewModel = new CategoryDetailsViewModel { Name = category.Name, Id = category.Id , CreatedAt = category.CreatedAt, ModifiedAt= category.ModifiedAt};
            return View(categoryDetailsViewModel);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedAt,ModifiedAt")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryEditViewModel = new CategoryEditViewModel { Name = category.Name ,Id = category.Id};  
            return View(categoryEditViewModel);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(CategoryEditViewModel model)
        {
            // Update the student
            var currentCategory = _context.Categories.FirstOrDefault(c => c.Id == model.Id);
            if (currentCategory == null)
            {
                return NotFound();
            }
            currentCategory.Name = model.Name;


            // Call entity framework here to save these changes
            if (ModelState.IsValid)
            {
                _context.Update(currentCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currentCategory);

        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'EComContext.Categories'  is null.");
            }
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(long id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
