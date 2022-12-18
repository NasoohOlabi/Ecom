﻿using AutoMapper;
using DB.Models;
using DB.UOW;
using Ecom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Controllers
{
    public class CategoryController : BaseController<CategoryController>
    {
        //private readonly Specs specs;
        public CategoryController(ILogger<CategoryController> logger, IUnitOfWork uow, IMapper mapper) : base(logger, uow, mapper)
        {
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            _logger.Log(LogLevel.Information, "Hello from log");
            var Model = from c in await _uow.Categories.GetAsync() 
                        select _mapper.Map<CategoryDetailsViewModel>(c);
            return View(Model);
        }

        public async Task<IActionResult> Attributes(long id)
        {
            var category = _uow.Categories.Get(
                x => x.Id == id,
                includeProperties: 
                "CategoryHasAttributes,CategoryHasAttributes.Attribute")
                .First();

            if (category == null)
            {
                return NotFound();
            }

            // Get all Attributes for the select list
            var AllAttributes = from attr in await _uow.Attributes.GetAsync()
                                select _mapper.Map<SelectAttributeViewModel>(attr);

            var editCategoryAttributesViewModel = 
                _mapper.Map<EditCategoryAttributesViewModel>(category);
            editCategoryAttributesViewModel.SelectAttributes = AllAttributes;

            return View(editCategoryAttributesViewModel);
        }
        // GET: Category/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _uow.Categories
                .GetByIDAsync((long)id);

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
                _uow.Categories.Insert(category);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _uow.Categories.GetByIDAsync((long)id);
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

            var currentCategory = await _uow.Categories.GetByIDAsync(model.Id);

            if (currentCategory == null)
            {
                return NotFound();
            }

            // Call entity framework here to save these changes
            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Categories.Update(_mapper.Map(model, currentCategory));
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(currentCategory.Id))
                    {
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
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _uow.Categories
                .GetByIDAsync((long)id);

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

            var category = await _uow.Categories.GetByIDAsync(id);

            if (category != null)
            {
                _uow.Categories.Delete(category);
            }

            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(long id)
        {
            return _uow.Categories.GetByID(id) != null;
        }
        
        [HttpPatch]
        public IActionResult SaveList([FromBody] EditCategoryAttributesViewModel editCategoryAttributeViewModel)
        {
            if (
                string.IsNullOrEmpty(editCategoryAttributeViewModel.Name)
                || Duplicates(from attr in editCategoryAttributeViewModel.CategoryAttributes
                              select attr.Name)
            )
            {
                return ValidationProblem();
            }

            _uow.Categories.UpdateAttributeList(editCategoryAttributeViewModel.Id,
                from selectItem in editCategoryAttributeViewModel.CategoryAttributes
                select selectItem.Id);

            try
            {
                //_uow.Categories.Update(_mapper.Map(category, editCategoryAttributeViewModel));
                _uow.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(editCategoryAttributeViewModel.Id))
                {
                    return NotFound();
                }
                else
                    throw;
            }

            return Json(RespondWithMessage("Attributes Changed"));

        }
    }

}
