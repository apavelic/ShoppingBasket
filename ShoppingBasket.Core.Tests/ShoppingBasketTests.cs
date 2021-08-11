using ShoppingBasket.Core.Models;
using ShoppingBasket.Core.Services;
using System.Collections.Generic;
using Xunit;
using ShoppingBasket.Core.Interfaces;
using System.Linq;

namespace ShoppingBasket.Core.Tests
{
	public class ShoppingBasketTests
	{
		private IShoppingBasketLogger _logger;
		private IDiscountService _discountService;

		public ShoppingBasketTests()
		{
			_logger = new ShoppingBasketLogger();
			_discountService = new DiscountService(_logger);
		}

		[Fact]
		public void ShoppingBasket_Add()
		{
			// Arrange
			var shoppingBasket = new ShoppingBasket(_logger);

			// Act
			shoppingBasket.AddItem(ProductBuilder.Bread);

			// Assert
			Assert.Single(shoppingBasket.Items);
			Assert.Equal(ProductBuilder.Bread.Id, shoppingBasket.Items.FirstOrDefault().Id);
		}

		[Fact]
		public void ShoppingBasket_Remove()
		{
			// Arrange
			var shoppingBasket = new ShoppingBasket(_logger);

			// Act
			shoppingBasket.AddItem(ProductBuilder.Bread);
			shoppingBasket.AddItem(ProductBuilder.Milk);
			shoppingBasket.RemoveItem(ProductBuilder.Bread.Id);

			// Assert
			Assert.Single(shoppingBasket.Items);
			Assert.Equal(ProductBuilder.Milk.Id, shoppingBasket.Items.FirstOrDefault().Id);
		}		
	}
}
