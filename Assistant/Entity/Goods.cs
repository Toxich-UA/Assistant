using System;
using System.Collections;
using System.Collections.Generic;

namespace Assistant.Models
{
    public partial class Goods
    {
        public Goods()
        {
            OrderGoods = new HashSet<OrderGoods>();
        }

        public string ProductCode { get; set; }
        public string Category { get; set; }
	    public string ImgSrc { get; set; }

        public ICollection<OrderGoods> OrderGoods { get; set; }

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
