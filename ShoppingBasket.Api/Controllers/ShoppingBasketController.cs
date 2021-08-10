using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShoppingBasket.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingBasketController : ControllerBase
	{
		// GET: api/<ValuesController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<ShoppingBasketController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<ShoppingBasketController>
		[HttpPost]
		public void Insert([FromBody] string value)
		{
		}

		// PUT api/<ShoppingBasketController>/5
		[HttpPut("{id}")]
		public void Update(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ShoppingBasketController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
