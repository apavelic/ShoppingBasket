using ShoppingBasket.Core.Models;
using ShoppingBasket.Core.Services;
using ShoppingBasket.Core;
using System.Collections.Generic;
using Xunit;
using ShoppingBasket.Core.Interfaces;

namespace ShoppingBasket.Core.Tests
{
	public class ShoppingBasketScenarioTests
	{
		private IShoppingBasketLogger _logger;
		private IDiscountService _discountService;

		public ShoppingBasketScenarioTests()
		{
			_logger = new ShoppingBasketLogger();
			_discountService = new DiscountService(_logger);
		}

		[Fact]
		public void Scenario_OneOfEachTest()
		{
			// Arrange
			var discounts = new List<Discount>
			{
				DiscountBuilder.ButterBreadDiscount,
				DiscountBuilder.FourMilksDiscount
			};

			var shoppingBasket = new ShoppingBasket(_discountService, _logger, discounts);

			// Act
			shoppingBasket.AddItem(ProductBuilder.Bread);
			shoppingBasket.AddItem(ProductBuilder.Butter);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.ApplyDiscount();

			// Assert
			Assert.Equal(2.95m, shoppingBasket.TotalPrice);
		}

		[Fact]
		public void Scenario_TwoButtersTwoBreadsTest()
		{
			// Arrange
			var discounts = new List<Discount>
			{
				DiscountBuilder.ButterBreadDiscount,
				DiscountBuilder.FourMilksDiscount
			};

			var shoppingBasket = new ShoppingBasket(_discountService, _logger, discounts);

			// Act
			shoppingBasket.AddItem(ProductBuilder.Butter);
			shoppingBasket.AddItem(ProductBuilder.Butter);
			shoppingBasket.AddItem(ProductBuilder.Bread);
			shoppingBasket.AddItem(ProductBuilder.Bread);
			shoppingBasket.ApplyDiscount();

			// Assert
			Assert.Equal(3.10m, shoppingBasket.TotalPrice);
		}

		[Fact]
		public void Scenario_FourMilksTest()
		{
			// Arrange
			var discounts = new List<Discount>
			{
				DiscountBuilder.ButterBreadDiscount,
				DiscountBuilder.FourMilksDiscount
			};

			var shoppingBasket = new ShoppingBasket(_discountService, _logger, discounts);

			// Act
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.ApplyDiscount();

			// Assert
			Assert.Equal(3.45m, shoppingBasket.TotalPrice);
		}

		[Fact]
		public void Scenario_EightMilksOneBreadTwoButtersTest()
		{
			// Arrange
			var discounts = new List<Discount>
			{
				DiscountBuilder.ButterBreadDiscount,
				DiscountBuilder.FourMilksDiscount
			};

			var shoppingBasket = new ShoppingBasket(_discountService, _logger, discounts);

			// Act
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Bread);
			shoppingBasket.AddItem(ProductBuilder.Butter);
			shoppingBasket.AddItem(ProductBuilder.Butter);
			shoppingBasket.ApplyDiscount();

			// Assert
			Assert.Equal(9.00m, shoppingBasket.TotalPrice);
		}

		[Fact]
		public void Scenario_FourMilksTwoBreadsTest()
		{
			// Arrange
			var discounts = new List<Discount>
			{
				DiscountBuilder.MilkBreadDiscount,
				DiscountBuilder.FourMilksDiscount
			};

			var shoppingBasket = new ShoppingBasket(_discountService, _logger, discounts);

			// Act
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.AddItem(ProductBuilder.Bread);
			shoppingBasket.AddItem(ProductBuilder.Bread);
			shoppingBasket.ApplyDiscount();

			// Assert
			Assert.Equal(3.85m, shoppingBasket.TotalPrice);
		}
	}
}
