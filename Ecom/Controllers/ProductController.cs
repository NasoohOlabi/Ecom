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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
//using MVCareas.Areas.Products.Controllers;
namespace Ecom.Controllers
{
    public class ProductController : BaseController<ProductController>
    {
        private readonly SignInManager<User> SignInManager;
        private readonly UserManager<User> UserManager;
        public ProductController(
            ILogger<ProductController> logger,
            IUnitOfWork uow,
            IMapper mapper,
            SignInManager<User> SignInManager,
            UserManager<User> UserManager
            ) : base(logger, uow, mapper)
        {
            this.SignInManager = SignInManager;
            this.UserManager = UserManager;
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
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_uow.Categories.Get(), "Id", "Name");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ProductEditViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            var user = await UserManager.GetUserAsync(User);
            product.SellerId = user.Id;
            if (ModelState.IsValid)
            {
                _uow.Products.Insert(product);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<ProductEditViewModel>(product));
        }

        // GET: Product/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(long id)
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

            return View(_mapper.Map<ProductEditViewModel>(product));
        }

        // POST: Product/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            var currentProduct = await _uow.Products.GetByIDAsync(model.Id);
            if (currentProduct == null)
            {
                return NotFound();
            }
            var sellerId = currentProduct.SellerId;
            _mapper.Map(model, currentProduct);
            currentProduct.SellerId = sellerId;
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
                return RedirectToAction(nameof(Specifications), new
                {
                    id = currentProduct.Id
                });
            }
            return View(currentProduct);
        }

        // GET: Product/Delete/5
        [Authorize]
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
        [Authorize]
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


        [Route("Product/{id:int}/Specifications")]
        [Authorize]
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
                                select _mapper.Map<AttributeDetailsViewModel>(attr);

            var CategoryAttributes = from attr in product.Category!.CategoryHasAttributes
                                     select _mapper.Map<AttributeDetailsViewModel>(attr.Attribute);


            var editProductAttributesViewModel =
                _mapper.Map<EditProductSpecificationsViewModel>(product);

            editProductAttributesViewModel.AllAttributes = AllAttributes;
            editProductAttributesViewModel.CategoryAttributes = CategoryAttributes;

            return View(editProductAttributesViewModel);
        }

        [Authorize]
        public IActionResult SaveList([FromBody] EditProductSpecificationsViewModel editProductSpecificationsViewModel)
        {

            var product = _uow.Products.Get(
               x => x.Id == editProductSpecificationsViewModel.Id,
               includeProperties:
               "Specifications,Specifications.Attribute,Specifications.SpecificationValue,Category,Category.CategoryHasAttributes,Category.CategoryHasAttributes.Attribute")
               .First();

            foreach (var specif in product.Specifications!)
            {
                if (!editProductSpecificationsViewModel.ProductSpecifications!.Select(x => x.Id).Any(x => x == specif.Id))
                {
                    _uow.Specifications.Delete(specif);
                    _uow.SpecificationValues.Delete(specif.SpecificationValue!);
                }
            }

            foreach (var newSpec in editProductSpecificationsViewModel.ProductSpecifications!)
            {
                if (!product.Specifications.Select(x => x.Id).Any(x => x == newSpec.Id))
                {
                    _uow.Specifications.Insert(new Specification
                    {
                        AttributeId = newSpec.Attribute!.Id,
                        ProductId = editProductSpecificationsViewModel.Id,
                        SpecificationValue = new SpecificationValue
                        {
                            Value = newSpec.SpecificationValue!.Value,
                        }
                    });
                }
            }
            try
            {
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
