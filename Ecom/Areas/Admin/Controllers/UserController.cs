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

namespace Ecom.sControllers
{
    [Area("Admin")]
    public class UserController : BaseController<UserController>
    {
        public UserController(ILogger<UserController> logger, IUnitOfWork uow, IMapper mapper) : base(logger, uow, mapper)
        {
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            IEnumerable<User> usersList = await _uow.Users.GetAsync(includeProperties: "Role");
            var users = new List<UserDetailsViewModel>();
            foreach (User u in usersList)
            {
                users.Add(_mapper.Map<UserDetailsViewModel>(u));
            }
            return View(users);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _uow.Users.GetAsync(filter: m => m.Id == id, includeProperties: "Role");

            if (user.Count() == 0)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserDetailsViewModel>(user.First()));
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_uow.Roles.Get(), "Id", "Name");
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserEditViewModel userEditViewModel)
        {
            if (ModelState.IsValid)
            {
                _uow.Users.Insert(_mapper.Map<User>(userEditViewModel));
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["RoleId"] = new SelectList(_uow.Roles.Get(), "Id", "Name", userEditViewModel.RoleId);
            return View(_mapper.Map<UserDetailsViewModel>(userEditViewModel));
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _uow.Users == null)
            {
                return NotFound();
            }

            var user = await _uow.Users.GetByIDAsync((long)id);

            if (user == null)
            {
                return NotFound();
            }
            //ViewData["RoleId"] = new SelectList(_uow.Roles.Get(), "Id", "Name", user.RoleId);

            return View(_mapper.Map<UserEditViewModel>(user));
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditViewModel userEditViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    User? user = _uow.Users.GetByID(userEditViewModel.Id);
                    if (user == null)
                    {
                        return NotFound();
                    }
                    _uow.Users.Update(_mapper.Map(userEditViewModel, user));

                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userEditViewModel.Id))
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
            ViewData["RoleId"] = new SelectList(_uow.Roles.Get(), "Id", "Name", userEditViewModel.RoleId);
            return View(_mapper.Map<UserDetailsViewModel>(userEditViewModel));
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _uow.Users == null)
            {
                return NotFound();
            }

            var user = await _uow.Users.GetAsync(filter: m => m.Id == id, includeProperties: "Role");

            if (user.Count() == 0)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserDetailsViewModel>(user.First()));
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_uow.Users == null)
            {
                return Problem("Entity set 'EComContext.Users'  is null.");
            }
            var user = await _uow.Users.GetByIDAsync(id);
            if (user != null)
            {
                _uow.Users.Delete(user);
            }

            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(long id)
        {
            return _uow.Users.GetByID(id) != null;
        }
    }
}
