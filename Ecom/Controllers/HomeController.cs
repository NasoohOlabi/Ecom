using AutoMapper;
using DB.UOW;
using Ecom.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ecom.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public HomeController(ILogger<HomeController> logger, IUnitOfWork uow, IMapper mapper) : base(logger, uow, mapper) 
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}