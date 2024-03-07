﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_proje.ViewComponents.Service
{
	public class ServiceList:ViewComponent
	{
		ServiceManager serviceManager = new ServiceManager(new EfServiceDal());

		public IViewComponentResult Invoke()
		{
			var values = serviceManager.Getlist();
			return View(values);

		}
	}
}
