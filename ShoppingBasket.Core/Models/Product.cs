using ShoppingBasket.Core.Enumerations;
using System;

namespace ShoppingBasket.Models.Core
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public bool IsDiscountApplied { get; set; }
		public ProductType Type { get; set; }
	}
}
