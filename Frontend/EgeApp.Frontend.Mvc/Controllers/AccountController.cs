using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EgeApp.Frontend.Mvc.Data.Entities;
using EgeApp.Frontend.Mvc.Helpers.Abstract;
using EgeApp.Frontend.Mvc.Models.Identity;
using Microsoft.Extensions.Logging;
using EgeApp.Frontend.Mvc.Models.Category;
using EgeApp.Frontend.Mvc.Models.Product;

namespace EgeApp.Frontend.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly INotyfService _notyfService;
        private readonly IEmailSenderHelper _emailSender;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            UserManager<AppUser> userManager,
            INotyfService notyfService,
            SignInManager<AppUser> signInManager,
            IEmailSenderHelper emailSender,
            RoleManager<AppRole> roleManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _notyfService = notyfService;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            var categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = 1, Name = "Kategori 1" },
                new CategoryViewModel { Id = 2, Name = "Kategori 2" },
                new CategoryViewModel { Id = 3, Name = "Kategori 3" }
            };

            var products = new List<ProductViewModel>
            {
                new ProductViewModel { Id = 1, Name = "Ürün 1", Price = 100, ImageUrl = "/images/product1.jpg" },
                new ProductViewModel { Id = 2, Name = "Ürün 2", Price = 200, ImageUrl = "/images/product2.jpg" }
            };

            var model = new LoginViewModel
            {
                CategoryList = categories,
                ProductList = products,
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Formda hata var!");
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı!");
                _notyfService.Error("Kullanıcı bulunamadı!");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError(string.Empty, "Email adresiniz doğrulanmamış!");
                _notyfService.Warning("Email doğrulaması gerekiyor!");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Geçersiz giriş!");
                _notyfService.Error("Giriş başarısız!");
                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "~/");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _notyfService.Success("Başarıyla çıkış yaptınız.");
            return Redirect("~/");
        }
        [HttpGet]
        public IActionResult Register()
        {
            var model = new CreateUserProfileViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateUserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Kayıt formunda hata var!");
                return View(model);
            }

            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { token, email = user.Email }, Request.Scheme);

                try
                {
                    await _emailSender.SendEmailAsync(user.Email, "Email Doğrulama",
                        $"Lütfen doğrulamak için <a href='{confirmationLink}'>buraya tıklayın</a>");
                    _notyfService.Success("Email doğrulama bağlantısı gönderildi!");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Email gönderimi sırasında hata.");
                    _notyfService.Error("Email gönderimi başarısız.");
                }

                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Profil güncellemesi başarısız!");
                return RedirectToAction("Index");
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                _notyfService.Error("Kullanıcı bulunamadı.");
                return RedirectToAction("Index");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.UserName;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                _notyfService.Error(result.Errors.FirstOrDefault()?.Description ?? "Güncelleme başarısız!");
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrWhiteSpace(model.CurrentPassword) && !string.IsNullOrWhiteSpace(model.NewPassword))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    _notyfService.Error(passwordChangeResult.Errors.FirstOrDefault()?.Description ?? "Parola güncelleme başarısız!");
                    return RedirectToAction("Index");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            _notyfService.Success("Profil başarıyla güncellendi!");
            return RedirectToAction("Index");
        }
    }
}