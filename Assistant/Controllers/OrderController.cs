using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Models;
using Assistant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;


namespace Assistant.Controllers
{
    public class OrderController : Controller
    {
		private AssistantContext _context;

	    public OrderController(AssistantContext context)
	    {
		    _context = context;
	    }

		
		// GET: /<controller>/
		public IActionResult Index(int? orderId)
		{
			if (orderId == null)
			{
				return NotFound();
			}

			var ordersGoods = _context.OrderGoods
								.Include(id => id.Goods)
								.Include(id => id.Orders)
								.Include(id => id.Formats)
								.Include(id => id.Orders.Customers)
								.Where(id => id.OrderId == orderId)
								.OrderBy(id => id.FormatId).ToList();

			ViewBag.Format = ordersGoods[0].FormatId;
			
			

			return View(ordersGoods);
        }

	    public IActionResult List()
	    {
		    var orders = _context.Orders;
		    return View(orders);
	    }


	    public IActionResult Create()
	    {

			//Create DropDownList from database table
		    List<OrderCreateViewModel> custom = new List<OrderCreateViewModel>{};

		    var rez = _context.Customers;
		    foreach (var item in rez)
		    {
			    custom.Add(new OrderCreateViewModel { Id = item.Id.ToString(), FirstName = item.FirstName+" "+item.LastName});
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
				//_context.Add(order);
				
				return RedirectToAction("Index", "Goods");
			}
			return RedirectToAction("Create");
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
