using ShoppingBasket.Core.Enumerations;
using ShoppingBasket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Models.Core
{
	public class Discount
	{
		public List<DiscountItem> Requirements { get; set; }
		public ProductType Target { get; set; }
		public int DiscountPercentage { get; set; }
	}
}
