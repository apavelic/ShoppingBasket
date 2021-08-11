using ShoppingBasket.Models.Core;
using System;

namespace ShoppingBasket.Core.Interfaces
{
	public interface IShoppingBasketService
	{
		void Add(Product product);
		void Remove(Guid id);
		decimal GetBasketPriceWithDiscount();
	}
}
