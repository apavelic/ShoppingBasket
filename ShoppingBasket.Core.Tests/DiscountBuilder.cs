using ShoppingBasket.Core.Enumerations;
using ShoppingBasket.Core.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBasket.Core.Tests
{
	public class DiscountBuilder
	{
		public static Discount ButterBreadDiscount => new Discount
		{
			Id = Guid.NewGuid(),
			Name = "Butter Bread Discount",
			Requirements = new List<DiscountItem>
			{
				new DiscountItem { Type = ProductType.Butter, Quantity = 2 },
				new DiscountItem { Type = ProductType.Bread, Quantity = 1 }
			},
			Target = ProductType.Bread,
			DiscountPercentage = 50
		};

		public static Discount MilkBreadDiscount => new Discount
		{
			Id = Guid.NewGuid(),
			Name = "Milk Bread Discount",
			Requirements = new List<DiscountItem>
			{
				new DiscountItem { Type = ProductType.Milk, Quantity = 2 },
				new DiscountItem { Type = ProductType.Bread, Quantity = 1 }
			},
			Target = ProductType.Bread,
			DiscountPercentage = 80
		};

		public static Discount FourMilksDiscount => new Discount
		{
			Id = Guid.NewGuid(),
			Name = "Four Milks Discount",
			Requirements = new List<DiscountItem>
			{
				new DiscountItem { Type = ProductType.Milk, Quantity = 4 },
			},
			Target = ProductType.Milk,
			DiscountPercentage = 100
		};


	}
}
