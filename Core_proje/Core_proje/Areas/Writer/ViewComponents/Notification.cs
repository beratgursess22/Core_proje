using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
namespace Core_proje.Areas.Writer.ViewComponents
{
	public class Notification:ViewComponent
	{
		AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
		public IViewComponentResult Invoke()
		{
			var values=announcementManager.TGetList().Take(5).ToList();
			return View(values);
		}
	}
}
