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
using AutoMapper;
using DB.UOW;
using Microsoft.Extensions.Logging;

namespace Ecom.Controllers
{
    public class ProductController : BaseController<ProductController>
    {
        public ProductController(ILogger<ProductController> logger, IUnitOfWork uow, IMapper mapper) : base(logger, uow, mapper)
        {
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _uow.Products.GetAsync(includeProperties: "Category,Seller");
            var productsList = new List<ProductDetailsViewModel>();
            foreach (Product p in products)
            {
                productsList.Add(_mapper.Map<ProductDetailsViewModel>(p));
            }
            return View(productsList);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _uow.Products == null)
            {
                return NotFound();
            }

            var product = await _uow.Products.GetByIDAsync((long)id);

            if (product == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProductDetailsViewModel>(product));
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_uow.Categories.Get(), "Id", "Name");
            ViewData["SellerId"] = new SelectList(_uow.Users.Get(), "Id", "FirstName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductEditViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            if (ModelState.IsValid)
            {
                _uow.Products.Insert(product);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<ProductEditViewModel>(product));
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _uow.Products == null)
            {
                return NotFound();
            }

            var product = await _uow.Products.GetByIDAsync((long)id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_uow.Categories.Get(), "Id", "Name", product.CategoryId);
            ViewData["SellerId"] = new SelectList(_uow.Users.Get(), "Id", "FirstName", product.SellerId);

            return View(_mapper.Map<ProductEditViewModel>(product));
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            var currentProduct = await _uow.Products.GetByIDAsync(model.Id);
            if (currentProduct == null)
            {
                return NotFound();
            }
            _mapper.Map(model, currentProduct);

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Products.Update(currentProduct);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(currentProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(currentProduct);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _uow.Products == null)
            {
                return NotFound();
            }

            var product = await _uow.Products.GetByIDAsync((long)id);

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
            if (_uow.Products == null)
            {
                return Problem("Entity set 'EComContext.Products'  is null.");
            }
            var product = await _uow.Products.GetByIDAsync(id);
            if (product != null)
            {
                _uow.Products.Delete(product.Id);
            }

            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _uow.Products.GetByID(id) != null;
        }
        [HttpGet]
        public async Task<IActionResult> Specifications(long id)
        {
            var product = _uow.Products.Get(
                x => x.Id == id,
                includeProperties:
                "Specifications,Specifications.Attribute,Specifications.SpecificationValue,Category,Category.CategoryHasAttributes,Category.CategoryHasAttributes.Attribute")
                .First();

            if (product == null)
            {
                return NotFound();
            }

            // Get all Attributes for the select list
            var AllAttributes = from attr in await _uow.Attributes.GetAsync()
                                select _mapper.Map<SelectAttributeViewModel>(attr);
            var CategoryAttributes = from attr in product.Category.CategoryHasAttributes
                                     select _mapper.Map<SelectAttributeViewModel>(attr.Attribute);


            var editProductAttributesViewModel =
                _mapper.Map<EditProductSpecificationsViewModel>(product);
            //FIXME: 
            editProductAttributesViewModel.ProductSpecifications = from x in product.Specifications
                                             select new SelectSpecificationViewModel
                                             {
                                                 Attribute = new 
                                                 EditAttributeViewModel
                                                 {
                                                     Id = x.Attribute.Id,
                                                     Name = x.Attribute.Name
                                                 },
                                                 Value = new SelectValueViewModel
                                                 {
                                                     Id = x.SpecificationValue.Id,
                                                     Value = x.SpecificationValue.Value
                                                 },
                                                Id= x.Id
                                             };
            editProductAttributesViewModel.AllAttributes = AllAttributes;
            editProductAttributesViewModel.CategoryAttributes = CategoryAttributes;

            return View(editProductAttributesViewModel);
        }
        public IActionResult SaveList([FromBody] EditProductSpecificationsViewModel editProductSpecificationsViewModel)
        {
            _uow.Products
                 .UpdateSpecificationsList(
                 _mapper.Map<DB.Repos.EditProductSpecificationsViewModel>(editProductSpecificationsViewModel)
                 );

            try
            {
                //_uow.Categories.Update(_mapper.Map(category, editProductSpecificationsViewModel));
                _uow.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(editProductSpecificationsViewModel.Id))
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
