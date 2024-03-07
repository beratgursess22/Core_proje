using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace Core_proje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial() 
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMassage() 
        {
            return PartialView();
        
        }

		[HttpPost]
		public PartialViewResult SendMassage(Message p)
		{
			MessageManager messageManager = new MessageManager(new EfMessageDal());
			p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			p.Status = true;
			messageManager.TAdd(p);
			return PartialView();

		}
	}
}
