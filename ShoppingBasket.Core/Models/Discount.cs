using ShoppingBasket.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Models.Core
{
	public class Discount
	{
		public List<ProductType> Requirements { get; set; }
		public ProductType Target { get; set; }
		public int DiscountPercentage { get; set; }
	}
}
