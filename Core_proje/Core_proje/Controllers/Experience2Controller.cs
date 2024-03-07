using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BusinessLayer.Concrete;
using Newtonsoft.Json;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace Core_proje.Controllers
{
	[Authorize(Roles = "Admin")]
	public class Experience2Controller : Controller
	{
		ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ListExperience()
		{
			var values = JsonConvert.SerializeObject(experienceManager.TGetList());
			return Json(values);
		}

		[HttpPost]
		public IActionResult AddExperience(ExperienceManager p)
		{
			experienceManager.TAdd(p);
			var values = JsonConvert.SerializeObject(p);
			return Json(values);
		}

		public IActionResult GetById(int ExperienceID)
		{
			var v= experienceManager.TGetByID(ExperienceID);
			var values = JsonConvert.SerializeObject(v);
			return Json(values);
		}
		public IActionResult DeleteExperience(int id)
		{
			var v = experienceManager.TGetByID(id);
			experienceManager.TDelete(v);
			return NoContent();
		}
	}
}
