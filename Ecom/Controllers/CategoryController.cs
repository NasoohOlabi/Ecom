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
using DB.UOW;

namespace Ecom.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EComContext _context;

        private readonly ILogger<Category> _logger;

        private readonly UnitOfWork _uow;

        public CategoryController(EComContext context, ILogger<Category> logger)
        {
            _context = context;
            _logger = logger;
            _uow = new UnitOfWork(_context, _logger);
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            _logger.Log(LogLevel.Information, "Hello from log");
            IEnumerable<Category> l = await _uow.CategoryRepositry.GetAllAsync();
            var x = new List<CategoryDetailsViewModel>();
            foreach (Category c in l)
            {
                x.Add(new CategoryDetailsViewModel(c));
            }
            return View(x);
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _uow.CategoryRepositry == null)
            {
                return NotFound();
            }

            var category = await _uow.CategoryRepositry
                .GetAsync((long)id);
            if (category == null)
            {
                return NotFound();
            }
            CategoryDetailsViewModel categoryDetailsViewModel = new(category);
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
                _uow.CategoryRepositry.Add(category);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _uow.CategoryRepositry == null)
            {
                return NotFound();
            }

            var category = await _uow.CategoryRepositry.GetAsync((long)id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryEditViewModel = new CategoryEditViewModel(category);
            return View(categoryEditViewModel);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(CategoryEditViewModel model)
        {
 
            var currentCategory = await _uow.CategoryRepositry.GetAsync(model.Id);
            if (currentCategory == null)
            {
                return NotFound();
            }
            currentCategory.Name = model.Name;


            // Call entity framework here to save these changes
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(currentCategory.Id)) {
                        return NotFound();
                    }
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(currentCategory);

        }

        // GET: Category/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null || _uow.CategoryRepositry == null)
            {
                return NotFound();
            }

            var category = _uow.CategoryRepositry
                .DeleteAsync((long)id);
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
            if (_uow.CategoryRepositry == null)
            {
                return Problem("Entity set 'EComContext.Categories'  is null.");
            }
            var category = await _uow.CategoryRepositry.GetAsync(id);
            if (category != null)
            {
                _uow.CategoryRepositry.Delete(category.Id);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(long id)
        {
            return _uow.CategoryRepositry.Get(id) != null;
        }
    }
}
