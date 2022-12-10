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
            IEnumerable<Product> l = await _uow.Products.GetAllAsync();
            var x = new List<ProductDetailsViewModel>();
            foreach (Product p in l)
            {
                x.Add(_mapper.Map<ProductDetailsViewModel>(p));
            }
            return View(x);

            //var detailsViewModels =
            //    from p in (await _context.Products
            //        .Include(p => p.Category)
            //        .Include(p => p.Seller).ToListAsync())
            //    select _mapper.Map<ProductDetailsViewModel>(p);

            //return View(detailsViewModels);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _uow.Products == null)
            {
                return NotFound();
            }

            //var product = await _context.Products
            //    .Include(p => p.Category)
            //    .Include(p => p.Seller)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var product = await _uow.Products.GetAsync((long)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProductDetailsViewModel>(product));
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_uow.Categories.GetAll(), "Id", "Name");
            ViewData["SellerId"] = new SelectList(_uow.Categories.GetAll(), "Id", "FirstName");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductEditViewModel productViewModel)
        {
            //var product = _mapper.Map<Product>(model);

            //if (ModelState.IsValid)
            //{
            //    _context.Add(product);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            //ViewData["SellerId"] = new SelectList(_context.Users, "Id", "FirstName", product.SellerId);
            //return View(product);

            var product = _mapper.Map<Product>(productViewModel);
            if (ModelState.IsValid)
            {
                _uow.Products.Add(product);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _uow.Products == null)
            {
                return NotFound();
            }

            var product = await _uow.Products.GetAsync((long)id);
            if (product == null)
            {
                return NotFound();
            }

            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            //ViewData["SellerId"] = new SelectList(_context.Users, "Id", "FirstName", product.SellerId);

            return View(_mapper.Map<ProductEditViewModel>(product));
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            var currentProduct = await _uow.Products.GetAsync(model.Id);
            if (currentProduct == null)
            {
                return NotFound();
            }
            _mapper.Map(model, currentProduct);

            // Call entity framework here to save these changes
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

            var product = await _uow.Products.GetAsync((long)id);

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
            var product = await _uow.Products.GetAsync(id);
            if (product != null)
            {
                _uow.Products.Delete(product.Id);
            }

            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _uow.Products.Get(id) != null;
        }
    }
}
