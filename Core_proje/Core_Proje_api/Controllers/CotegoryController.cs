using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_Proje_api.ApiContext;
using Core_Proje_api.Entity;

namespace Core_Proje_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CotegoryController : ControllerBase
	{
		[HttpGet]
		public IActionResult CategoryList()
		{
			using var c = new Context();
			return Ok(c.Categories.ToList());
		}
		[HttpGet ("{id}")]
		public IActionResult CategoryGetByID(int id) 
		{
			using var c= new Context();
			var values = c.Categories.Find(id);
			if (values == null)
			{
				return NoContent();
			}
			else
			{
				return Ok(values);
			}
		}
		[HttpPost]
		public IActionResult CategoryAdd(Category p)
		{
			using var c = new Context();
			c.Add(p);
			c.SaveChanges();
			return Created("", p);

		}
		[HttpDelete]
		public IActionResult CategoryDelete(int id)
		{
			using var c = new Context();
			var values=c.Categories.Find(id);	
			if (values == null)
			{
				return NotFound();
			}
			else
			{
				c.Remove(values);
				c.SaveChanges ();
				return NoContent();
			}
		}
		[HttpPut]
		public IActionResult CategoryUpdate(Category p)
		{
			using var c = new Context();
			var values = c.Find<Category>(p.CategoryID);
			if (values == null)
			{
				return NotFound();
			}
			else
			{
				values.CategoryName = p.CategoryName;
				c.Update(values);
				c.SaveChanges();
				return NoContent();
			}
		}
	}
}
