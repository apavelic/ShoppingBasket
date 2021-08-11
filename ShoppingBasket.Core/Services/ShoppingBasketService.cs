using ShoppingBasket.Core.Interfaces;
using ShoppingBasket.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket.Services.Core
{
	public class ShoppingBasketService : IShoppingBasketService
	{
		private IDiscountService _discountService;
		private readonly IEnumerable<Discount> _discounts;

		private List<Product> _basket { get; set; }

		public void Add(Product product)
		{
			_basket.Add(product);
		}

		public void Remove(Guid id)
		{
			var product = _basket.FirstOrDefault(x => x.Id == id);
			_basket.Remove(product);
		}

		public ShoppingBasketService(IDiscountService discountService, IEnumerable<Discount> discounts = null)
		{
			_discountService = discountService;
			_discounts = discounts ?? _discountService.GetDiscounts();
			_basket = new List<Product>();
		}

		public decimal GetBasketPriceWithDiscount()
		{
			var productTypes = _basket
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
					var targets = _basket.Where(x => x.Type == discount.Target && !x.IsDiscountApplied).Take(numberOfProductsOnDiscount).ToList();

					targets.ForEach(target =>
					{
						target.Price = target.Price * (1 - discount.DiscountPercentage / 100m);
						target.IsDiscountApplied = true;
					});
				}
			}

			return _basket.Sum(x => x.Price);
		}
	}
}
