using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assistant.Entity;

namespace Assistant.Models
{
    public partial class Orders
    {
		public Orders()
		{
			OrderGoods = new HashSet<OrderGoods>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[DisplayName("Customer ID")]
		
		public int CustomerId { get; set; }

		
		//[Required]
		[DisplayName("Description")]
		public string Description { get; set; }

		//[Required]
		[DisplayName("Order price")]
		public string OrderPrice { get; set; }

		//[Required]
		public string Invoice { get; set; }


		public Customers Customers { get; set; }

		public ICollection<OrderGoods> OrderGoods { get; set; }

		public IEnumerator GetEnumerator()
	    {
		    throw new NotImplementedException();
	    }
    }
}
