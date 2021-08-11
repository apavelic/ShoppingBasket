using ShoppingBasket.Core.Models;
using System;

namespace ShoppingBasket.Core.Interfaces
{
	public interface IShoppingBasket
	{
		void AddItem(Product product);
		void RemoveItem(Guid id);
		void ApplyDiscount();
	}
}
