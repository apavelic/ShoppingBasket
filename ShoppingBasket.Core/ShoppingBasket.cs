using ShoppingBasket.Core.Interfaces;
using ShoppingBasket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket.Core
{
	public class ShoppingBasket : IShoppingBasket
	{
		public decimal TotalPrice => _items.Sum(x => x.Price);

		private IDiscountService _discountService;
		private IEnumerable<Discount> _discounts;
		private IShoppingBasketLogger _logger;
		private List<Product> _items;

		public List<Product> Items => _items;

		public ShoppingBasket(IDiscountService discountService, IShoppingBasketLogger logger, IEnumerable<Discount> discounts = null)
		{
			_discountService = discountService;
			_discounts = discounts ?? _discountService.GetDiscounts();
			_logger = logger;
			_items = new List<Product>();
		}

		public void AddItem(Product product)
		{
			try
			{
				_items.Add(product);
				_logger.Log($"Item added: {product.ToString()}");
			}
			catch (Exception e)
			{
				_logger.Log($"Error in {nameof(ShoppingBasket)}, Method: {nameof(ShoppingBasket.AddItem)}: {e.Message}");
			}
		}

		public void RemoveItem(Guid id)
		{
			try
			{
				var product = _items.FirstOrDefault(x => x.Id == id);
				_items.Remove(product);
				_logger.Log($"Item Removed: {product.ToString()}");
			}
			catch (Exception e)
			{
				_logger.Log($"Error in {nameof(ShoppingBasket)}, Method: {nameof(ShoppingBasket.RemoveItem)}: {e.Message}");
			}
		}

		public void ApplyDiscount()
		{
			try
			{
				var productTypes = _items
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
						var targets = _items.Where(x => x.Type == discount.Target && !x.IsDiscountApplied).Take(numberOfProductsOnDiscount).ToList();

						targets.ForEach(target =>
						{
							target.Price = target.Price * (1 - discount.DiscountPercentage / 100m);
							target.IsDiscountApplied = true;


							_logger.Log($"Discount applied: {target.ToString()}");
						});
					}
				}
			}
			catch (Exception e)
			{
				_logger.Log($"Error in {nameof(ShoppingBasket)}, Method: {nameof(ShoppingBasket.ApplyDiscount)}: {e.Message}");
			}
		}
	}
}
