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

		private IShoppingBasketLogger _logger;
		private List<Product> _items;

		public List<Product> Items => _items;

		public ShoppingBasket(IShoppingBasketLogger logger)
		{
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
	}
}
