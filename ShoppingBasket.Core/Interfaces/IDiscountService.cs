using ShoppingBasket.Models.Core;
using System.Collections.Generic;

namespace ShoppingBasket.Core.Interfaces
{
	public interface IDiscountService
	{
		IEnumerable<Discount> GetDiscounts();
	}
}
