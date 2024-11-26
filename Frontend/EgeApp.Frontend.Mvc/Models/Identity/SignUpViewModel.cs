using System;
using System.ComponentModel.DataAnnotations;

namespace EgeApp.Frontend.Mvc.Models.Identity;

public class SignUpViewModel
{
    [Display(Name = "Ad")]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
    [MinLength(3, ErrorMessage = "En az 3 karakter olmalı")]
    [MaxLength(20, ErrorMessage = "En fazla 20 karakter olmalı")]
    public string FirstName { get; set; }

    [Display(Name = "Soyad")]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
    [MinLength(3, ErrorMessage = "En az 3 karakter olmalı")]
    [MaxLength(20, ErrorMessage = "En fazla 20 karakter olmalı")]
    public string LastName { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Geçersiz email adresi")]
    public string Email { get; set; }

    [Display(Name = "Kullanıcı Adı")]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
    [MinLength(3, ErrorMessage = "En az 3 karakter olmalı")]
    [MaxLength(15, ErrorMessage = "En fazla 15 karakter olmalı")]
    public string UserName { get; set; }

    [Display(Name = "Parola")]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
    [MinLength(8, ErrorMessage = "En az 8 karakter olmalı")]
    [MaxLength(15, ErrorMessage = "En fazla 15 karakter olmalı")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Parola Tekrar")]
    [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Parola aynı değil")]
    public string RePassword { get; set; }

    [Display(Name = "Telefon Numarası")]
    [Phone(ErrorMessage = "Geçersiz telefon numarası formatı")]
    public string PhoneNumber { get; set; }
}
