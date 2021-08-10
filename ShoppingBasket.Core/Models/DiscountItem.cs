using ShoppingBasket.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Core.Models
{
	public class DiscountItem
	{
		public ProductType Type { get; set; }
		public int Quantity { get; set; }
	}
}
