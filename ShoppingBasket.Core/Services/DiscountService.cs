using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoppingBasket.Core.Interfaces;
using ShoppingBasket.Models.Core;
using System.Collections.Generic;
using System.IO;

namespace ShoppingBasket.Services.Core
{
	public class DiscountService : IDiscountService
	{
		private readonly IConfiguration Configuration;
		public DiscountService(IConfiguration configuration = null)
		{
			Configuration = configuration;
		}
		public IEnumerable<Discount> GetDiscounts() 
			=> JsonConvert.DeserializeObject<IEnumerable<Discount>>(File.ReadAllText(Configuration["DiscountsPath"]));
	}
}
