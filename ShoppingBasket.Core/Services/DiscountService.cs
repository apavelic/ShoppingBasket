using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoppingBasket.Core.Interfaces;
using ShoppingBasket.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ShoppingBasket.Core.Services
{
	public class DiscountService : IDiscountService
	{
		private IConfiguration _configuration;
		private IShoppingBasketLogger _logger;

		public DiscountService(IShoppingBasketLogger logger, IConfiguration configuration = null)
		{
			_logger = logger;
			_configuration = configuration;
		}
		public IEnumerable<Discount> GetDiscounts()
		{
			try
			{
				return JsonConvert.DeserializeObject<IEnumerable<Discount>>(File.ReadAllText(_configuration["DiscountsPath"]));
			}
			catch (Exception e)
			{
				_logger.Log($"Error in {nameof(DiscountService)}, Method: {nameof(DiscountService.GetDiscounts)}: {e.Message}");
				return null;
			}
		}
	}
}
