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
using AutoMapper;

namespace Ecom.Controllers
{
    public class CategoryController : GenericController<CategoryController>
    {
        public CategoryController(IUnitOfWork uow, ILoggerFactory logger, IMapper mapper) : base(uow, logger, mapper)
        {
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            Logger.Log(LogLevel.Information, "Hello from log");
            var models = from c in await UOW.CategoryRepositry.GetAllAsync()
                    select Mapper.Map<CategoryDetailsViewModel>(c);
            return View(models);
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var category = await UOW.CategoryRepositry
                .GetAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            var categoryDetailsViewModel = Mapper.Map<CategoryDetailsViewModel>(category);
            return View(categoryDetailsViewModel);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                UOW.CategoryRepositry.Add(category);
                await UOW.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || UOW.CategoryRepositry == null)
            {
                return NotFound();
            }

            var category = await UOW.CategoryRepositry.GetAsync((long)id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryEditViewModel = Mapper.Map<CategoryEditViewModel>(category);
            return View(categoryEditViewModel);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(CategoryEditViewModel model)
        {
 
            var currentCategory = await UOW.CategoryRepositry.GetAsync(model.Id);
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
                    UOW.CategoryRepositry.Update(currentCategory);
                    await UOW.SaveChangesAsync();
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
            if (id == null || UOW.CategoryRepositry == null)
            {
                return NotFound();
            }

            var category = UOW.CategoryRepositry
                .Get((long)id);

            if (category == null)
            {
                return NotFound();
            }
            
            return View(Mapper.Map<CategoryDetailsViewModel>(category));
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (UOW.CategoryRepositry == null)
            {
                return Problem("Entity set 'EComContext.Categories'  is null.");
            }
            var category = await UOW.CategoryRepositry.GetAsync(id);
            if (category != null)
            {
                UOW.CategoryRepositry.Delete(category.Id);
            }

            await UOW.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(long id)
        {
            return UOW.CategoryRepositry.Get(id) != null;
        }
    }
}
