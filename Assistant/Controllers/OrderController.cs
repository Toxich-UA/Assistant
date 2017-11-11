using System;
using System.Linq;
using Assistant.Models;
using Microsoft.AspNetCore.Mvc;
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
			
			var ordersGoods = db.OrderGoods.Include(id => id.Goods)
								.Include(id => id.Orders)
								.Where(id => id.OrderId == orderId)
								.OrderBy(id => id.FormatId);
		
			return View(ordersGoods);
        }
    }
}
