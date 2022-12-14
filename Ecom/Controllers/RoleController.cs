using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DB.Models;
using DB.UOW;
using AutoMapper;

namespace Ecom.Controllers
{
    //public class RoleController : GenericController<RoleController>
    //{

    //    public RoleController(IUnitOfWork uow, ILoggerFactory logger, IMapper mapper) : base(uow, logger, mapper)
    //    {
    //    }



    //    // GET: Role
    //    public async Task<IActionResult> Index()
    //    {
    //          return View(await UOW.Roles.ToListAsync());
    //    }

    //    // GET: Role/Details/5
    //    public async Task<IActionResult> Details(long? id)
    //    {
    //        if (id == null || UOW.Roles == null)
    //        {
    //            return NotFound();
    //        }

    //        var role = await UOW.Roles
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (role == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(role);
    //    }

    //    // GET: Role/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Role/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Id,Name,CreatedAt,ModifiedAt")] Role role)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            UOW.Add(role);
    //            await UOW.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(role);
    //    }

    //    // GET: Role/Edit/5
    //    public async Task<IActionResult> Edit(long? id)
    //    {
    //        if (id == null || UOW.Roles == null)
    //        {
    //            return NotFound();
    //        }

    //        var role = await UOW.Roles.FindAsync(id);
    //        if (role == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(role);
    //    }

    //    // POST: Role/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,CreatedAt,ModifiedAt")] Role role)
    //    {
    //        if (id != role.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                UOW.Update(role);
    //                await UOW.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!RoleExists(role.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(role);
    //    }

    //    // GET: Role/Delete/5
    //    public async Task<IActionResult> Delete(long? id)
    //    {
    //        if (id == null || UOW.Roles == null)
    //        {
    //            return NotFound();
    //        }

    //        var role = await UOW.Roles
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (role == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(role);
    //    }

    //    // POST: Role/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(long id)
    //    {
    //        if (UOW.Roles == null)
    //        {
    //            return Problem("Entity set 'EComContext.Roles'  is null.");
    //        }
    //        var role = await UOW.Roles.FindAsync(id);
    //        if (role != null)
    //        {
    //            UOW.Roles.Remove(role);
    //        }
            
    //        await UOW.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool RoleExists(long id)
    //    {
    //      return UOW.Roles.Any(e => e.Id == id);
    //    }
    //}

}
