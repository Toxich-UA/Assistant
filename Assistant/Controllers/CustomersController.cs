using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assistant.Controllers
{
    public class CustomersController : Controller
    {
		private AssistantContext _context;

		public CustomersController(AssistantContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var cuntomers = _context.Customers;
            return View(cuntomers);
        }
		public IActionResult Create()
		{
			return View();
		}
		public IActionResult Edit()
		{
			return View();
		}
		public IActionResult Delete()
		{
			return View();
		}
	}
}