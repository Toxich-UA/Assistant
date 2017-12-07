using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assistant.Controllers
{
	public class FormatsController : Controller
	{
		private AssistantContext _context;

		public FormatsController(AssistantContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var formats = _context.Formars;
			return View(formats);
		}
		public IActionResult Create(int id)
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