using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Core_proje.ViewComponents.Dashboard
{
    public class AdminNotificationNavbarList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
