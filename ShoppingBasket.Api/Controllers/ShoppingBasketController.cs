using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.Core.Interfaces;
using ShoppingBasket.Core.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBasket.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingBasketController : ControllerBase
	{
		private IShoppingBasket _shoppingBasket;
		private IDiscountService _discountService;

		public ShoppingBasketController(
			IShoppingBasket shoppingBasket,
			IDiscountService discountService)
		{
			_shoppingBasket = shoppingBasket;
			_discountService = discountService;
		}

		// GET: api/<ValuesController>
		[HttpGet]
		public IEnumerable<Product> Get(bool withDiscount = false)
		{
			if (withDiscount)
				_discountService.ApplyDiscounts(_shoppingBasket.Items);

			return _shoppingBasket.Items;
		}

		// POST api/<ShoppingBasketController>
		[HttpPost]
		public void Insert(Product product)
		{
			_shoppingBasket.AddItem(product);
		}

		// DELETE api/<ShoppingBasketController>/5
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			_shoppingBasket.RemoveItem(id);
		}
	}
}
