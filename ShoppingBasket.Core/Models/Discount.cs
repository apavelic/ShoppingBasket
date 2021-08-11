using ShoppingBasket.Core.Enumerations;
using ShoppingBasket.Core.Models;
using System.Collections.Generic;

namespace ShoppingBasket.Models.Core
{
	public class Discount
	{
		public List<DiscountItem> Requirements { get; set; }
		public ProductType Target { get; set; }
		public int DiscountPercentage { get; set; }
	}
}
