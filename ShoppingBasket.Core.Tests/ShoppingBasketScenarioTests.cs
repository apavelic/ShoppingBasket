using ShoppingBasket.Services.Core;
using System.Collections.Generic;
using Xunit;
using ShoppingBasket.Models.Core;

namespace ShoppingBasket.Core.Tests
{
	public class ShoppingBasketScenarioTests
	{

		[Fact]
		public void Scenario_OneOfEachTest()
		{
			// Arrange
			var discounts = new List<Discount>
			{
				DiscountBuilder.ButterBreadDiscount,
				DiscountBuilder.FourMilksDiscount
			};

			ShoppingBasketService shoppingBasketService = new ShoppingBasketService(new DiscountService(), discounts);

			// Act
			shoppingBasketService.Add(ProductBuilder.Bread);
			shoppingBasketService.Add(ProductBuilder.Butter);
			shoppingBasketService.Add(ProductBuilder.Milk);
			
			// Assert
			Assert.Equal(2.95m, shoppingBasketService.GetBasketPriceWithDiscount());
		}

		[Fact]
		public void Scenario_DiscountTwoButtersTwoBreadsTest()
		{
			// Arrange
			var discounts = new List<Discount>
			{
				DiscountBuilder.ButterBreadDiscount,
				DiscountBuilder.FourMilksDiscount
			};

			ShoppingBasketService shoppingBasketService = new ShoppingBasketService(new DiscountService(), discounts);

			// Act
			shoppingBasketService.Add(ProductBuilder.Butter);
			shoppingBasketService.Add(ProductBuilder.Butter);
			shoppingBasketService.Add(ProductBuilder.Bread);
			shoppingBasketService.Add(ProductBuilder.Bread);

			// Assert
			Assert.Equal(3.10m, shoppingBasketService.GetBasketPriceWithDiscount());
		}

		[Fact]
		public void Scenario_DiscountFourMilksTest()
		{
			// Arrange
			var discounts = new List<Discount>
			{
				DiscountBuilder.ButterBreadDiscount,
				DiscountBuilder.FourMilksDiscount
			};

			ShoppingBasketService shoppingBasketService = new ShoppingBasketService(new DiscountService(), discounts);

			// Act
			shoppingBasketService.Add(ProductBuilder.Milk);
			shoppingBasketService.Add(ProductBuilder.Milk);
			shoppingBasketService.Add(ProductBuilder.Milk);
			shoppingBasketService.Add(ProductBuilder.Milk);

			// Assert
			Assert.Equal(3.45m, shoppingBasketService.GetBasketPriceWithDiscount());
		}

		[Fact]
		public void Scenario_DiscountEightMilksOneBreadTwoButtersTest()
		{
			// Arrange
			var discounts = new List<Discount>
			{
				DiscountBuilder.ButterBreadDiscount,
				DiscountBuilder.FourMilksDiscount
			};

			ShoppingBasketService shoppingBasketService = new ShoppingBasketService(new DiscountService(), discounts);

			// Act
			shoppingBasketService.Add(ProductBuilder.Milk);
			shoppingBasketService.Add(ProductBuilder.Milk);
			shoppingBasketService.Add(ProductBuilder.Milk);
			shoppingBasketService.Add(ProductBuilder.Milk);
			shoppingBasketService.Add(ProductBuilder.Milk);
			shoppingBasketService.Add(ProductBuilder.Milk);
			shoppingBasketService.Add(ProductBuilder.Milk);
			shoppingBasketService.Add(ProductBuilder.Bread);
			shoppingBasketService.Add(ProductBuilder.Butter);
			shoppingBasketService.Add(ProductBuilder.Butter);

			// Assert
			Assert.Equal(9.00m, shoppingBasketService.GetBasketPriceWithDiscount());
		}
	}
}
