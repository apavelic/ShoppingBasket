using ShoppingBasket.Core.Enumerations;
using ShoppingBasket.Models.Core;
using System;

namespace ShoppingBasket.Core.Tests
{
	public class ProductBuilder
	{
		public static Product Bread => new Product
		{
			Id = Guid.Parse("25546792-9A4C-E911-93A5-144F8A014C66"),
			Name = "Bread",
			Type = ProductType.Bread,
			Price = 1,
			IsDiscountApplied = false
		};

		public static Product Butter => new Product
		{
			Id = Guid.Parse("26546792-9A4C-E911-93A5-144F8A014C66"),
			Name = "Butter",
			Type = ProductType.Butter,
			Price = 0.8m,
			IsDiscountApplied = false
		};

		public static Product Milk => new Product
		{
			Id = Guid.Parse("27546792-9A4C-E911-93A5-144F8A014C66"),
			Name = "Milk",
			Type = ProductType.Milk,
			Price = 1.15m,
			IsDiscountApplied = false
		};
	}
}
