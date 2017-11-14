using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Entity;
using Assistant.Models;
using Assistant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Assistant.Controllers
{
    public class OrderController : Controller
    {
		private AssistantContext db = new AssistantContext();



		// GET: /<controller>/
		public IActionResult Index(int orderId)
		{
			
			var ordersGoods = db.OrderGoods
								.Include(id => id.Goods)
								.Include(id => id.Orders)
								.Include(id => id.Formats)
								.Where(id => id.OrderId == orderId)
								.OrderBy(id => id.FormatId).ToList();

			ViewBag.Format = ordersGoods[0].FormatId;
			

			return View(ordersGoods);
        }


	    public IActionResult Create()
	    {

			//Create DropDownList from database table
		    List<OrderIndexViewModel> custom = new List<OrderIndexViewModel>{};

		    var rez = db.Customers;
		    foreach (var item in rez)
		    {
			    custom.Add(new OrderIndexViewModel { Id = item.Id.ToString(), FirstName = item.FirstName});
		    }
			
			ViewData["Customers"] = new SelectList(custom.AsEnumerable(), "Id", "FirstName");
			return View();
	    }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Orders order)
	    {
			if (ModelState.IsValid)
			{
				int customer = order.CustomerId;
			    string description = order.Description;
			    string orderPrice = order.OrderPrice;
			    string invoice = order.Invoice;
			    Console.WriteLine("DEBUG: \nCustomer: " + customer + "\nDescription: " + description + "\nOrderPrice: " +
			                      orderPrice + "\nInvoice: " + invoice);
			    Console.WriteLine(TryValidateModel(order));

				return RedirectToAction("Index", "Home");
			}
			return RedirectToAction("Create");
		}
	}
}
