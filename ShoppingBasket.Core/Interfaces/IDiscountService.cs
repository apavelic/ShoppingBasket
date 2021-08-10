using ShoppingBasket.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Core.Interfaces
{
	public interface IDiscountService
	{
		IEnumerable<Discount> GetDiscounts();
	}
}
