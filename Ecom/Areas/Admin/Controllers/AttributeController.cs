using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DB.Models;
using AutoMapper;
using DB.UOW;
using Ecom.Models;
using Attribute = DB.Models.Attribute;
using Ecom.Controllers;

namespace Ecom.Controllers
{
    [Area("Admin")]
    public class AttributeController : BaseController<AttributeController>
    {
        public AttributeController(ILogger<AttributeController> logger, IUnitOfWork uow, IMapper mapper) : base(logger, uow, mapper)
        {
        }

        // GET: Attribute
        public async Task<IActionResult> Index()
        {
            ViewBag.activeLink = "Attribute";
            IEnumerable<Attribute> Attributes = await _uow.Attributes.GetAsync();
            var AttributesList = new List<AttributeDetailsViewModel>();
            foreach (Attribute c in Attributes)
            {
                AttributesList.Add(_mapper.Map<AttributeDetailsViewModel>(c));
            }
            return View(AttributesList);
        }

        // GET: Attribute/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            ViewBag.activeLink = "Attribute";
            if (id == null)
            {
                return NotFound();
            }

            var Attribute = await _uow.Attributes
                .GetByIDAsync((long)id);

            if (Attribute == null)
            {
                return NotFound();
            }

            AttributeDetailsViewModel AttributeDetailsViewModel = _mapper.Map<AttributeDetailsViewModel>(Attribute);
            return View(AttributeDetailsViewModel);
        }

        // GET: Attribute/Create
        public IActionResult Create()
        {
            ViewBag.activeLink = "Attribute";
            return View();
        }

        // POST: Attribute/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttributeEditViewModel AttributeViewModel)
        {
            ViewBag.activeLink = "Attribute";
            var Attribute = _mapper.Map<Attribute>(AttributeViewModel);
            if (ModelState.IsValid)
            {
                _uow.Attributes.Insert(Attribute);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Attribute);
        }

        // GET: Attribute/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            ViewBag.activeLink = "Attribute";
            if (id == null)
            {
                return NotFound();
            }

            var Attribute = await _uow.Attributes.GetByIDAsync((long)id);
            if (Attribute == null)
            {
                return NotFound();
            }
            var AttributeEditViewModel = _mapper.Map<AttributeEditViewModel>(Attribute);
            return View(AttributeEditViewModel);
        }

        // POST: Attribute/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AttributeEditViewModel model)
        {
            ViewBag.activeLink = "Attribute";
            var currentAttribute = await _uow.Attributes.GetByIDAsync(model.Id);

            if (currentAttribute == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Attributes.Update(_mapper.Map(model, currentAttribute));
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeExists(currentAttribute.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(currentAttribute);
        }

        // GET: Attribute/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            ViewBag.activeLink = "Attribute";
            if (id == null)
            {
                return NotFound();
            }

            var Attribute = await _uow.Attributes
                .GetByIDAsync((long)id);

            if (Attribute == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<AttributeDetailsViewModel>(Attribute));
        }

        // POST: Attribute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            ViewBag.activeLink = "Attribute";
            if (_uow.Attributes == null)
            {
                return Problem("Entity set 'EComContext.Attributes'  is null.");
            }
            var Attribute = await _uow.Attributes.GetByIDAsync(id);

            if (Attribute != null)
            {
                _uow.Attributes.Delete(Attribute);
            }

            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributeExists(long id)
        {
            ViewBag.activeLink = "Attribute";
            return _uow.Attributes.GetByID(id) != null;
        }
    }
}
