using Assistant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assistant.Controllers
{
    public class HomeController : Controller
    {
		private AssistantContext _context;

	    public HomeController(AssistantContext context)
	    {
		    _context = context;
	    }

	    public IActionResult Index()
		{
			var order = _context.Orders.Include(d => d.Customers);
            return View(order);
        }

        public IActionResult About()
        {
            

            return View();
        }

		public IActionResult Settings()
        {
            

            return View();
        }
		
	}
}
