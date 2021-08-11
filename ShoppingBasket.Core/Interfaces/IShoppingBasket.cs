using ShoppingBasket.Core.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBasket.Core.Interfaces
{
	public interface IShoppingBasket
	{
		List<Product> Items { get; }
		void AddItem(Product product);
		void RemoveItem(Guid id);
	}
}
