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
    [Authorize(Roles = "Admin")]
    public class DashboardController : BaseController<DashboardController>
    {
        public DashboardController(ILogger<DashboardController> logger, IUnitOfWork uow, IMapper mapper) : base(logger, uow, mapper)
        {
        }
        public IActionResult Index()
        {
            ViewBag.activeLink = "Dashboard";
            return View();
        }
    }
}
