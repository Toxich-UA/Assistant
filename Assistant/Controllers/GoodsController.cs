using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assistant.Controllers
{ 
    public class GoodsController : Controller
    {
		private AssistantContext db = new AssistantContext();

		// GET: /<controller>/
		public IActionResult Index(string goodsId)
        {
	        var customer = db.Goods.FirstOrDefault(c => c.ProductCode == goodsId);

            return View(customer);
        }
    }
}
