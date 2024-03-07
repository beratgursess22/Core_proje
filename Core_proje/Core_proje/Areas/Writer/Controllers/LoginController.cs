using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Core_proje.Areas.Writer.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace Core_proje.Areas.Writer.Controllers
{
	[AllowAnonymous]
	[Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class LoginController : Controller
	{
		private readonly SignInManager<WriterUser> _singInManager;

		public LoginController(SignInManager<WriterUser> singInManager)
		{
			_singInManager = singInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserLoginViewModel p)
		{
			if (ModelState.IsValid)
			{
				var result = await _singInManager.PasswordSignInAsync(p.UserName, p.Password, true, true);
				if(result.Succeeded)
				{
					return RedirectToAction("Index", "Profile");
				}
				else
				{
					ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
				}
			}
			return View();
			
		}
		public async Task<IActionResult> LogOut()
		{
			await _singInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");

		}
	}
}
