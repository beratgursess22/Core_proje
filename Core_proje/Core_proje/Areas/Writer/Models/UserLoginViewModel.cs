using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace Core_proje.Areas.Writer.Models
{
	public class UserLoginViewModel
	{
        [Display(Name ="Kullanıcı Adınız ")]
        [Required(ErrorMessage ="Kullanıcı Adınızı Giriniz..")]

        public string UserName { get; set; }

		[Display(Name = "Şifrenizi")]
		[Required(ErrorMessage = "Şifrenizi Giriniz..")]
		public string Password { get; set; }
    }
}
