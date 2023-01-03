using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
