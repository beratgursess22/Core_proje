using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using System.Security.Cryptography.Xml;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace Core_proje.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ContactController : Controller
	{
		MessageManager messageManager = new MessageManager(new EfMessageDal());
		
		public IActionResult Index()
		{
			var values = messageManager.TGetList();
			return View(values);
		}
		public IActionResult ContactDelete(int id)
		{
			var values=messageManager.TGetByID(id);
			messageManager.TDelete(values);
			return RedirectToAction("Index");
		}
		public IActionResult ContactDetail(int id)
		{
			var values = messageManager.TGetByID(id);
			return View(values);

		}
	}
}
