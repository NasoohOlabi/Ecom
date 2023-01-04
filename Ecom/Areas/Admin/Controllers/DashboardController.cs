using System.Data;
using AutoMapper;
using DB.Models;
using DB.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    [Area("Admin")]
    public class DashboardController : BaseController<DashboardController>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public DashboardController(ILogger<DashboardController> logger, IUnitOfWork uow, IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager) : base(logger, uow, mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            //if (!_signInManager.IsSignedIn(User))
            //{
            //    return Unauthorized();
            //}

            //var user = _uow.Users.GetByID(1);
            //var result = await _userManager.GetRolesAsync(user);
            //var user = _uow.Users.Get(
            //    x => x.Id == 10003,
            //    includeProperties:
            //    "AspNetRoles")
            //    .First();
            //bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            //if (!isAdmin)
            //{
            //    return Unauthorized();
            //}

            ViewBag.activeLink = "Dashboard";
            return View();
        }
    }
}
