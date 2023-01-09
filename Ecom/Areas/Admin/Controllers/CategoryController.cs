using AutoMapper;
using DB.Models;
using DB.UOW;
using Ecom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Ecom.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
            ViewBag.activeLink = "Category";
            return View(Model);
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.activeLink = "Category";
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
                                select _mapper.Map<AttributeDetailsViewModel>(attr);

            var editCategoryAttributesViewModel =
                _mapper.Map<EditCategoryAttributesViewModel>(category);
            editCategoryAttributesViewModel.AllAttributes = AllAttributes;

            return View(editCategoryAttributesViewModel);
        }
        // GET: Category/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            ViewBag.activeLink = "Category";
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
            ViewBag.activeLink = "Category";
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryEditViewModel categoryViewModel)
        {
            ViewBag.activeLink = "Category";
            var category = _mapper.Map<Category>(categoryViewModel);
            if (ModelState.IsValid)
            {
                _uow.Categories.Insert(category);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

      
        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            ViewBag.activeLink = "Category";
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
            ViewBag.activeLink = "Category";
            if (_uow.Categories == null)
            {
                return Problem("Entity set 'EComContext.Categories'  is null.");
            }

            var category = await _uow.Categories.GetByIDAsync(id);

            if (category != null)
            {

                _uow.Categories.DeleteAttributeList(id);

                _uow.Categories.Delete(category);
            }

            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(long id)
        {
            return _uow.Categories.GetByID(id) != null;
        }

        // PATCH: Category/Edit/5
        [HttpPatch]
        public IActionResult SaveList([FromBody] EditCategoryAttributesViewModel editCategoryAttributeViewModel)
        {
            ViewBag.activeLink = "Category";

            if (
                string.IsNullOrEmpty(editCategoryAttributeViewModel.Name)
                || Duplicates(from attr in editCategoryAttributeViewModel.CategoryAttributes
                              select attr.Name)
            )
            {
                return ValidationProblem();
            }
            var currentCategory =
                _uow.Categories.Get(
                    x => x.Id == editCategoryAttributeViewModel.Id,
                    includeProperties: "CategoryHasAttributes,CategoryHasAttributes.Attribute"
                    ).First();


            if (currentCategory is null)
            {
                return NotFound();
            }

            currentCategory.Name = editCategoryAttributeViewModel.Name;

            _uow.Categories.UpdateAttributeList(currentCategory,
                from selectItem in editCategoryAttributeViewModel.CategoryAttributes
                select selectItem.Id);
            try
            {
                _uow.Categories.Update(currentCategory);
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
