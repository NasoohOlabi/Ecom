﻿using System;
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
    public class CategoryController : BaseController<CategoryController>
    {
        public CategoryController(ILogger<CategoryController> logger, IUnitOfWork uow, IMapper mapper) : base(logger, uow, mapper)
        {
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            _logger.Log(LogLevel.Information, "Hello from log");
            IEnumerable<Category> l = await _uow.Categories.GetAllAsync();
            var x = new List<CategoryDetailsViewModel>();
            foreach (Category c in l)
            {
                x.Add(_mapper.Map<CategoryDetailsViewModel>(c));
            }
            return View(x);
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _uow.Categories == null)
            {
                return NotFound();
            }

            var category = await _uow.Categories
                .GetAsync((long)id);
            if (category == null)
            {
                return NotFound();
            }
            CategoryDetailsViewModel categoryDetailsViewModel = _mapper.Map<CategoryDetailsViewModel>(category);
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
        public async Task<IActionResult> Create(CategoryEditViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            if (ModelState.IsValid)
            {
                _uow.Categories.Add(category);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _uow.Categories == null)
            {
                return NotFound();
            }

            var category = await _uow.Categories.GetAsync((long)id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryEditViewModel = _mapper.Map<CategoryEditViewModel>(category);
            return View(categoryEditViewModel);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(CategoryEditViewModel model)
        {
 
            var currentCategory = await _uow.Categories.GetAsync(model.Id);
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
                    _uow.Categories.Update(currentCategory);
                    await _uow.SaveChangesAsync();
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
            if (id == null || _uow.Categories == null)
            {
                return NotFound();
            }

            var category = _uow.Categories
                .Get((long)id);

            if (category == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<CategoryDetailsViewModel>(category));
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_uow.Categories == null)
            {
                return Problem("Entity set 'EComContext.Categories'  is null.");
            }
            var category = await _uow.Categories.GetAsync(id);
            if (category != null)
            {
                _uow.Categories.Delete(category.Id);
            }

            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(long id)
        {
            return _uow.Categories.Get(id) != null;
        }
    }
}
