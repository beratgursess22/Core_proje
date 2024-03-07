using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
namespace Core_proje.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SocialMediaController : Controller
    {
        SocialMEdiaManager socialMEdiaManager = new SocialMEdiaManager(new EfSocialMediaDal());

        public IActionResult Index()
        {
            var values=socialMEdiaManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
            socialMEdiaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var values = socialMEdiaManager.TGetByID(id);
            socialMEdiaManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var values = socialMEdiaManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
           socialMEdiaManager.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
