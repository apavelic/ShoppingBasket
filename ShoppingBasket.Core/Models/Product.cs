using ShoppingBasket.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Models.Core
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public bool IsDiscountApplied { get; set; }
		public ProductType Type { get; set; }
	}
}
