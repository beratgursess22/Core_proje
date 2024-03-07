using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
namespace Core_proje.ViewComponents.SocialMedia
{
    public class SocialMediaList:ViewComponent
    {
        SocialMEdiaManager socialMEdiaManager = new SocialMEdiaManager(new EfSocialMediaDal());
        public IViewComponentResult Invoke()
        {
            var values= socialMEdiaManager.TGetList();
            return View(values);
        }
    }
}
