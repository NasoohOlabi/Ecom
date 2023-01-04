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
using Ecom.Controllers;

namespace Ecom.Controllers
{
    [Area("Admin")]
    public class RoleController : BaseController<RoleController>
    {
        public RoleController(ILogger<RoleController> logger, IUnitOfWork uow, IMapper mapper) : base(logger, uow, mapper)
        {
        }

        // GET: Role
        public async Task<IActionResult> Index()
        {
            ViewBag.activeLink = "Role";
            IEnumerable<Role> roles = await _uow.Roles.GetAsync();
            var rolesList = new List<RoleDetailsViewModel>();
            foreach (Role c in roles)
            {
                rolesList.Add(_mapper.Map<RoleDetailsViewModel>(c));
            }
            return View(rolesList);
        }

        // GET: Role/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            ViewBag.activeLink = "Role";
            if (id == null)
            {
                return NotFound();
            }

            var role = await _uow.Roles
                .GetByIDAsync((long)id);

            if (role == null)
            {
                return NotFound();
            }

            RoleDetailsViewModel roleDetailsViewModel = _mapper.Map<RoleDetailsViewModel>(role);
            return View(roleDetailsViewModel);
        }

        // GET: Role/Create
        public IActionResult Create()
        {
            ViewBag.activeLink = "Role";
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleEditViewModel roleViewModel)
        {
            ViewBag.activeLink = "Role";
            var role = _mapper.Map<Role>(roleViewModel);
            if (ModelState.IsValid)
            {
                _uow.Roles.Insert(role);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Role/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            ViewBag.activeLink = "Role";
            if (id == null)
            {
                return NotFound();
            }

            var role = await _uow.Roles.GetByIDAsync((long)id);
            if (role == null)
            {
                return NotFound();
            }
            var roleEditViewModel = _mapper.Map<RoleEditViewModel>(role);
            return View(roleEditViewModel);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleEditViewModel model)
        {
            ViewBag.activeLink = "Role";
            var currentRole = await _uow.Roles.GetByIDAsync(model.Id);

            if (currentRole == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Roles.Update(_mapper.Map(model, currentRole));
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(currentRole.Id))
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
            return View(currentRole);
        }

        // GET: Role/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            ViewBag.activeLink = "Role";
            if (id == null)
            {
                return NotFound();
            }

            var role = await _uow.Roles
                .GetByIDAsync((long)id);

            if (role == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<RoleDetailsViewModel>(role));
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            ViewBag.activeLink = "Role";
            if (_uow.Roles == null)
            {
                return Problem("Entity set 'EComContext.Roles'  is null.");
            }
            var role = await _uow.Roles.GetByIDAsync(id);

            if (role != null)
            {
                _uow.Roles.Delete(role);
            }

            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(long id)
        {
            ViewBag.activeLink = "Role";
            return _uow.Roles.GetByID(id) != null;
        }
    }
}
