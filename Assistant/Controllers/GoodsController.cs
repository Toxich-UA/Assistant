using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Models;
using Assistant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;


namespace Assistant.Controllers
{ 
    public class GoodsController : Controller
    {
		private AssistantContext _context ;

	    public GoodsController(AssistantContext context)
	    {
		    _context = context;
	    }

		

		// GET: /<controller>/
		public async Task<IActionResult> Index(string filter, int page = 1)
        {
			//Create DropDownList from database table
			List<OrderGoodsPickerViewModel> formats = new List<OrderGoodsPickerViewModel> { };
			var rez = _context.Formars;
			foreach (var item in rez)
			{
				formats.Add(new OrderGoodsPickerViewModel { Id = item.Id, Format = item.Format });
			}
			ViewData["Formats"] = new SelectList(formats.AsEnumerable(), "Id", "Format");



			var goods = _context.Goods.OrderBy(p => p.ProductCode).AsQueryable();

			if (!string.IsNullOrWhiteSpace(filter))
			{
				goods = goods.Where(p => p.ProductCode.Contains(filter));
			}
			var model = await PagingList.CreateAsync(goods, 12, page, "ProductCode", "ProductCode");

			model.RouteValue = new RouteValueDictionary {{ "filter", filter}};

			return View(model);
        }

		public async Task<IActionResult> List(int page = 1)
		{
			var goods = _context.Goods.OrderBy(p => p.ProductCode);
			var model = await PagingList.CreateAsync(goods, 12, page);
			return View(model);
		}

		public IActionResult Create(int id = 1)
		{
			return View();
		}

		public IActionResult Edit(int id = 1)
		{
			return View();
		}

		public IActionResult Delete(int id = 1)
		{
			return View();
		}
	}
}
