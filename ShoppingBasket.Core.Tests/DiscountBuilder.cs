using ShoppingBasket.Core.Enumerations;
using ShoppingBasket.Core.Models;
using ShoppingBasket.Models.Core;
using System.Collections.Generic;

namespace ShoppingBasket.Core.Tests
{
	public class DiscountBuilder
	{
		public static Discount ButterBreadDiscount => new Discount
		{
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
			Requirements = new List<DiscountItem>
			{
				new DiscountItem { Type = ProductType.Milk, Quantity = 4 },
			},
			Target = ProductType.Milk,
			DiscountPercentage = 100
		};


	}
}
