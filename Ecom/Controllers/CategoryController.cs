using AutoMapper;
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
            IEnumerable<Category> l = await _uow.Categories.GetAsync();
            var x = new List<CategoryDetailsViewModel>();
            foreach (Category c in l)
            {
                x.Add(_mapper.Map<CategoryDetailsViewModel>(c));
            }
            return View(x);
        }
        // GET: Category/
        public async Task<IActionResult> Attributes(long id)
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
            var attrs = from cate_attr in category.CategoryHasAttributes
                        select _mapper.Map<SelectAttributeViewModel>(cate_attr.Attribute);
            var AllAttributes = from attr in await _uow.Attributes.GetAsync()
                                select _mapper.Map<SelectAttributeViewModel>(attr);

            return View(new EditCategoryAttributesViewModel
            {
                Id = category.Id,
                Name = category.Name,
                CategoryAttributes = attrs,
                SelectAttributes = AllAttributes
            });
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
        private bool Duplicates(IEnumerable<string> lst)
        {
            return lst.Count() != lst.Distinct().Count();
        }
        [HttpPatch]
        public async Task<IActionResult> SaveList([FromBody] EditCategoryAttributesViewModel editCategoryAttributeViewModel)
        {
            if (
                string.IsNullOrEmpty(editCategoryAttributeViewModel.Name)
                || Duplicates(from attr in editCategoryAttributeViewModel.CategoryAttributes
                               select attr.Name)

            )
            {
                return ValidationProblem();
            }
            var category = await _uow.Categories.GetByIDAsync(editCategoryAttributeViewModel.Id);
            if (category == null)
            {
                NotFound();
            }

            category.CategoryHasAttributes = (from elem in editCategoryAttributeViewModel.CategoryAttributes
                                             select _mapper.Map<CategoryHasAttribute>(elem)).ToList();
            _uow.SaveChanges();

            try
            {
                //_uow.Categories.Update(_mapper.Map(category, editCategoryAttributeViewModel));
                await _uow.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.Id))
                {
                    return NotFound();
                }
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));


        }
    }

}
