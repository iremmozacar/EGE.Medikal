using System;
using System.ComponentModel.DataAnnotations;

namespace EgeApp.Frontend.Mvc.Models.Identity;

public class LoginViewModel
{
    [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz!")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Parola boş bırakılamaz!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string ReturnUrl { get; set; }
}
