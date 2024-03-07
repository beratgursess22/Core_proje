using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using System.Xml.Linq;

namespace Core_proje.Areas.Writer.Controllers
{

	[Area("Writer")]
	public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

		public DashboardController(UserManager<WriterUser> userManager)
		{
			_userManager = userManager;
		}

		public  async Task<IActionResult> Index()
        {
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.v1 = values.Name + " " + values.Surname;

			//Weather APi
			string api = "b751b78da2b7900e7cb083cc0a9b5c58";
			string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
			XDocument xDocument=XDocument.Load(connection);
			ViewBag.v6 = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value;


			//statistics
			Context context = new Context();
			ViewBag.v2 = context.WriterMessages.Where(x => x.Receiver == values.Email).Count();
			ViewBag.v3 = context.Announcements.Count();
			ViewBag.v4 = context.Users.Count();
		    ViewBag.v5 = context.Skills.Count();
            return View();
        }
    }
}
