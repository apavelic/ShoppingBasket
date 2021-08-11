using ShoppingBasket.Core.Enumerations;
using System;
using System.ComponentModel;

namespace ShoppingBasket.Core.Models
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		[DefaultValue(false)]
		public bool IsDiscountApplied { get; set; }
		public ProductType Type { get; set; }

		public override string ToString()
			=> $"\n\rId: {Id}\n\rName: {Name}\n\rPrice: {Price}\n\rType: {Type}\n\rDiscount Applied: {IsDiscountApplied}\n\r";
	}
}
