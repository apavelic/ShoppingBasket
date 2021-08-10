using Microsoft.Extensions.Configuration;
using Moq;
using ShoppingBasket.Services.Core;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using ShoppingBasket.Core.Interfaces;

namespace ShoppingBasket.Core.Tests
{
	public class UnitTest1
	{
		private Mock<IConfiguration> _configuration = new Mock<IConfiguration>();
		public UnitTest1()
		{
			_configuration.SetupGet(a => a["DiscountsPath"]).Returns("C:\\Users\\apavelic\\Documents\\Private\\ShoppingBasket\\ShoppingBasket.Core\\discounts.json");
		}
		[Fact]
		public void Test1()
		{
			var discountService = new DiscountService(_configuration.Object);
			var shoppingBasketService = new ShoppingBasketService(discountService);
			var price = shoppingBasketService.GetBasketPriceWithDiscount();
			//var discounts = service.GetDiscounts();


			var t = new List<int> { 1, 1, 1, 1 };
			var x = new List<int> { 1, 1, 1, 1, 2 };

			var n = t.Intersect(x).ToList();

			System.Console.WriteLine("test");


		}
	}
}
