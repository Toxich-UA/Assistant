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

			//var ordersGoods = db.OrderGoods.FromSql("select * from `Order-Goods` inner join Orders on orderId = Orders.id inner join goods on goodsId = goods.productCode where orderId = 1");
			
			var ordersGoods = db.OrderGoods.Include(id => id.Goods).Include(id => id.Order).Where(id => id.OrderId == orderId);
			
			//var ordersGoods = db.OrderGoods;
			



			return View(ordersGoods);
        }
    }
}
