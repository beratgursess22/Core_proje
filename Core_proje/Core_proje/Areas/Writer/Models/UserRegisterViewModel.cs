using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;
namespace Core_proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınınız Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen SoyAdınınız Giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen Görselinizi Ekleyiniz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adınınız Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz")]
        public string Mail { get; set; }
    }
}
