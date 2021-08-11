using ShoppingBasket.Core.Enumerations;
using System;

namespace ShoppingBasket.Core.Models
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public bool IsDiscountApplied { get; set; }
		public ProductType Type { get; set; }

		public override string ToString()
			=> $"\n\rId: {Id}\n\rName: {Name}\n\rPrice: {Price}\n\rType: {Type}\n\rDiscount Applied: {IsDiscountApplied}\n\r";
	}
}
