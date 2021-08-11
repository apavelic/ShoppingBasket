using ShoppingBasket.Core.Enumerations;
using System.Collections.Generic;

namespace ShoppingBasket.Core.Models
{
	public class Discount
	{
		public string Name { get; set; }
		public List<DiscountItem> Requirements { get; set; }
		public ProductType Target { get; set; }
		public int DiscountPercentage { get; set; }
	}
}
