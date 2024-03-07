using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Core_proje.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ErrorPageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Error404()
        {
            return View();
        }
    }
}
