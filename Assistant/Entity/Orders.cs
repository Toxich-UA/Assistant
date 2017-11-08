using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string Customer { get; set; }

        public string Description { get; set; }

        public string OrderPrice { get; set; }

        public string Invoice { get; set; }

		public ICollection<OrderGoods> OrderGoods { get; set; }

		public IEnumerator GetEnumerator()
	    {
		    throw new NotImplementedException();
	    }
    }
}
