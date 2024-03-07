using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Core_proje.Controllers
{
	[Authorize(Roles = "Admin")]
	public class WriterUserController : Controller
    {
        WriterUserManager WriterUserManager = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(WriterUserManager.Getlist());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddUser(WriterUserManager p)
        {
            WriterUserManager.Insert(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
