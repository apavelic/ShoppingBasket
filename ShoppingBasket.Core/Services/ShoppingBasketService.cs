using ShoppingBasket.Core.Enumerations;
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

		public List<Product> Products { get; set; }

		public ShoppingBasketService(IDiscountService discountService)
		{
			_discountService = discountService;
			_discounts = _discountService.GetDiscounts();

			Products = new List<Product>
			{
				new Product { Id = Guid.NewGuid(), Name = "P1", IsDiscountApplied = false, Price = 10, Type = ProductType.Milk  },
				new Product { Id = Guid.NewGuid(), Name = "P2", IsDiscountApplied = false, Price = 10, Type = ProductType.Milk  },
				new Product { Id = Guid.NewGuid(), Name = "P4", IsDiscountApplied = false, Price = 10, Type = ProductType.Milk  },
				new Product { Id = Guid.NewGuid(), Name = "P5", IsDiscountApplied = false, Price = 10, Type = ProductType.Milk  },
				new Product { Id = Guid.NewGuid(), Name = "P6", IsDiscountApplied = false, Price = 7, Type = ProductType.Butter },
				new Product { Id = Guid.NewGuid(), Name = "P7", IsDiscountApplied = false, Price = 8, Type = ProductType.Bread  }
			};
		}

		public double GetBasketPriceWithDiscount()
		{
			var productTypes = Products
				.GroupBy(p => p.Type)
				.ToDictionary(x => x.Key, x => x.Count());


			foreach (var discount in _discounts)
			{
				var hasDiscount = true;

				discount.Requirements.ForEach(requirement 
					=> hasDiscount = productTypes.ContainsKey(requirement.Type) && productTypes[requirement.Type] >= requirement.Quantity);

				if (hasDiscount)
				{
					var target = Products.FirstOrDefault(x => x.Type == discount.Target && !x.IsDiscountApplied);
					if (target != null)
					{
						target.Price = target.Price * (1 - discount.DiscountPercentage / 100.0);
						target.IsDiscountApplied = true;
					}
				}
			}

			return Products.Sum(x => x.Price);
		}
	}
}
