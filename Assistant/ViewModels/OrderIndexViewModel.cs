using System.Linq;
using Assistant.Models;

namespace Assistant.ViewModels
{
    public class OrderIndexViewModel
    {
		public IQueryable<Orders> Orders { get; set; }

	    public IQueryable<OrderGoods> OrderGoods { get; set; }
    }
}
