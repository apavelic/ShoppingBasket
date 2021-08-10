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
		public string Name { get; set; }
		public string Price { get; set; }
		public ProductType Type { get; set; }
	}
}
