using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace Core_proje.ViewComponents.Testimonial
{
	public class TestimonialList:ViewComponent
	{
		TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());

		public IViewComponentResult Invoke()
		{
			var values= testimonialManager.TGetList();
			return View(values);	
		}
	}
}
