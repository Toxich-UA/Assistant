using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assistant.Models
{
    public partial class OrderGoods
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int Count { get; set; }

        public int OrderId { get; set; }
        public string GoodsId { get; set; }
        public int FormatId { get; set; }


        public Goods Goods { get; set; }
        public Orders Orders { get; set; }
        public Formats Formats { get; set; }
    }
}
