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
using Attribute = DB.Models.Attribute;

namespace Ecom.Controllers
{
    public class AttributeController : BaseController<AttributeController>
    {
        //private readonly Specs specs;
        public AttributeController(ILogger<AttributeController> logger, IUnitOfWork uow, IMapper mapper) : base(logger, uow, mapper)
        {
        }

        //// GET: Category
        //public async Task<IActionResult> Index()
        //{
        //    _logger.Log(LogLevel.Information, "Hello from log");
        //    IEnumerable<Category> l = await _uow.Categories.GetAsync();
        //    var x = new List<CategoryDetailsViewModel>();
        //    foreach (Category c in l)
        //    {
        //        x.Add(_mapper.Map<CategoryDetailsViewModel>(c));
        //    }
        //    return View(x);
        //}
        //// GET: Category/
        //public async Task<IActionResult> Attributes(long id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _uow.Categories
        //        .GetByIDAsync((long)id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    var attrs = from cate_attr in category.CategoryHasAttributes
        //                select _mapper.Map<SelectAttributeViewModel>(cate_attr.Attribute);
        //    var AllAttributes = from attr in await _uow.Attributes.GetAsync()
        //                        select _mapper.Map<SelectAttributeViewModel>(attr);
            
        //    return View(new EditCategoryAttributesViewModel
        //    {
        //        Id = category.Id,
        //        Name = category.Name,
        //        CategoryAttributes = attrs,
        //        SelectAttributes = AllAttributes
        //    }) ;
        //}
        //// GET: Category/Details/5
        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _uow.Categories
        //        .GetByIDAsync((long)id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    CategoryDetailsViewModel categoryDetailsViewModel = _mapper.Map<CategoryDetailsViewModel>(category);
        //    return View(categoryDetailsViewModel);
        //}

        //// GET: Category/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateAttributeViewModel attributeViewModel)
        {
            var attribute = _mapper.Map<Attribute>(attributeViewModel);
            if (ModelState.IsValid)
            {
                _uow.Attributes.Insert(attribute);
                await _uow.SaveChangesAsync();
            }
            return Json(attribute);
        }

        //// GET: Category/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _uow.Categories.GetByIDAsync((long)id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    var categoryEditViewModel = _mapper.Map<CategoryEditViewModel>(category);
        //    return View(categoryEditViewModel);
        //}

        //// POST: Category/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Edit(CategoryEditViewModel model)
        //{
 
        //    var currentCategory = await _uow.Categories.GetByIDAsync(model.Id);

        //    if (currentCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    // Call entity framework here to save these changes
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _uow.Categories.Update(_mapper.Map(model, currentCategory));
        //            await _uow.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CategoryExists(currentCategory.Id)) {
        //                return NotFound();
        //            }
        //            else
        //                throw;
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(currentCategory);

        //}

        //// GET: Category/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _uow.Categories
        //        .GetByIDAsync((long)id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
            
        //    return View(_mapper.Map<CategoryDetailsViewModel>(category));
        //}

        //// POST: Category/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    if (_uow.Categories == null)
        //    {
        //        return Problem("Entity set 'EComContext.Categories'  is null.");
        //    }

        //    var category = await _uow.Categories.GetByIDAsync(id);

        //    if (category != null)
        //    {
        //        _uow.Categories.Delete(category);
        //    }

        //    await _uow.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CategoryExists(long id)
        //{
        //    return _uow.Categories.GetByID(id) != null;
        //}
    }
}
