using ShoppingBasket.Core.Models;
using System.Collections.Generic;

namespace ShoppingBasket.Core.Interfaces
{
	public interface IDiscountService
	{
		void ApplyDiscounts(IEnumerable<Product> products);
	}
}
