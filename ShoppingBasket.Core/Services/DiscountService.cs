using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoppingBasket.Core.Interfaces;
using ShoppingBasket.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingBasket.Core.Services
{
	public class DiscountService : IDiscountService
	{
		private IConfiguration _configuration;
		private IShoppingBasketLogger _logger;
		private IEnumerable<Discount> _discounts;

		public DiscountService(IShoppingBasketLogger logger, IEnumerable<Discount> discounts = null, IConfiguration configuration = null)
		{
			_logger = logger;
			_configuration = configuration;
			_discounts = discounts == null || !discounts.Any()
				? GetDiscounts()
				: discounts;
		}

		public void ApplyDiscounts(IEnumerable<Product> items)
		{
			try
			{
				var productTypes = items
						.Where(x => !x.IsDiscountApplied)
						.GroupBy(p => p.Type)
						.ToDictionary(x => x.Key, x => x.Count());

				foreach (var discount in _discounts)
				{
					var hasDiscount = true;
					var numberOfProductsOnDiscount = int.MaxValue;
					discount.Requirements.ForEach(requirement =>
					{
						if (!productTypes.ContainsKey(requirement.Type) || productTypes[requirement.Type] < requirement.Quantity)
						{
							hasDiscount = false;
							return;
						}
						var possibleTargetsForRequirement = productTypes[requirement.Type] / requirement.Quantity;
						numberOfProductsOnDiscount = possibleTargetsForRequirement < numberOfProductsOnDiscount ? possibleTargetsForRequirement : numberOfProductsOnDiscount;
					});

					if (hasDiscount)
					{
						var targets = FindTargets(discount.Requirements, items);

						targets.ForEach(target =>
						{
							if (target.Type == discount.Target && numberOfProductsOnDiscount-- > 0)
								target.Price = target.Price * (1 - discount.DiscountPercentage / 100m);

							target.IsDiscountApplied = true;
							_logger.Log($"Discount applied: {target.ToString()}");
						});
					}
				}
			}
			catch (Exception e)
			{
				_logger.Log($"Error in {nameof(DiscountService)}, Method: {nameof(DiscountService.ApplyDiscounts)}: {e.Message}");
			}
		}

		private IEnumerable<Discount> GetDiscounts()
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

		private List<Product> FindTargets(List<DiscountItem> requirements, IEnumerable<Product> items)
		{
			var itemsToReturn = new List<Product>();

			requirements.ForEach(requirement 
				=> itemsToReturn.AddRange(items.Where(x => !x.IsDiscountApplied && x.Type == requirement.Type).Take(requirement.Quantity).ToList()));

			return itemsToReturn;
		}
	}
}
