//using DB.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;



//namespace Ecom.Controllers
//{
//    public class StringValueController : Controller
//    {

//        private readonly EComContext _db;

//        public StringValueController(EComContext db)
//        {
//            _db = db;
//        }

//        // GET: StringValueController
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult Test()
//        {
//            StringValue stringValue = new StringValue();
//            stringValue.Value = "Hi";
//            DateTime dt = DateTime.Now;
//            stringValue.CreatedAt = dt;
//            stringValue.ModifiedAt = dt;
//            _db.Add(stringValue);
//            _db.SaveChanges();
//            return RedirectToAction("Index", "Home");
//        }

//    }
//}
