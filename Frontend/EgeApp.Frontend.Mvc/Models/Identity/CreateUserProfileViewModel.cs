using System;
using System.ComponentModel.DataAnnotations;

namespace EgeApp.Frontend.Mvc.Models.Identity
{
    public class CreateUserProfileViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçersiz email formatı")]
        public string Email { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string UserName { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Şifre")]
        public string Password { get; set; } = "Qwe123.,";

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler aynı değil")]
        public string RePassword { get; set; } = "Qwe123.,";
    }
}