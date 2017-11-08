using System.Linq;
using Assistant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assistant.Controllers
{
    public class HomeController : Controller
    {
		private AssistantContext db = new AssistantContext();

		public IActionResult Index()
		{

			//var order = (from r in db.Orders select r);
			var order = db.Orders;
            return View(order);
        }

        public IActionResult About()
        {
            

            return View();
        }
		//        public IActionResult Contact()
		//        {
		//            ViewData["Message"] = "Your contact page.";
		//
		//            return View();
		//        }
		//
		//        public IActionResult Error()
		//        {
		//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		//        }
	}
}
