using ShoppingBasket.Core.Enumerations;
using System;
using System.Collections.Generic;

namespace ShoppingBasket.Core.Models
{
	public class Discount
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<DiscountItem> Requirements { get; set; }
		public ProductType Target { get; set; }
		public int DiscountPercentage { get; set; }
	}
}
