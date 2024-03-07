using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Concrete;
using Core_proje.Areas.Writer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core_proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model= new UserEditViewModel();
            model.Name = values.Name;
            model.SurName = values.Surname;
            model.PictureURL = values.ImageUrl;
            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if(p.Picture!= null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelacotion = resource + "/wwwroot/Userimage/" + imagename;
                var stream = new FileStream(savelacotion, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                values.ImageUrl = imagename;
            }
            values.Name = p.Name;
            values.Surname = p.SurName;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);
            var result= await _userManager.UpdateAsync(values);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();

        }
    }
}
