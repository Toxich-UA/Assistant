using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assistant.Models
{
    public partial class Formats
    {
		public Formats()
		{
			OrderGoods = new HashSet<OrderGoods>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Format { get; set; }


		public ICollection<OrderGoods> OrderGoods { get; set; }

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
