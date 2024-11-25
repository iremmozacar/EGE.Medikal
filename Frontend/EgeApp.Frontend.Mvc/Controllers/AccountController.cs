using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EgeApp.Frontend.Mvc.Data.Entities;
using EgeApp.Frontend.Mvc.Helpers.Abstract;
using EgeApp.Frontend.Mvc.Models.Cart;
using EgeApp.Frontend.Mvc.Models.Email;
using EgeApp.Frontend.Mvc.Models.Identity;
using EgeApp.Frontend.Mvc.Services;
using EgeApp.Frontend.Mvc.Models.Order;

namespace EgeApp.Frontend.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly INotyfService _notyfService;
        private readonly IEmailSenderHelper _emailSender;

        public AccountController(
            UserManager<AppUser> userManager,
            INotyfService notyfService,
            SignInManager<AppUser> signInManager,
            IEmailSenderHelper emailSender,
            RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _notyfService = notyfService;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                _notyfService.Error("Kullanıcı bilgilerine ulaşılamadı.");
                return RedirectToAction("Login");
            }

            var userId = user.Id;
            var model = new UserProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };

            var ordersResult = await OrderService.GetOrdersByUserIdAsync(userId);
            model.Orders = ordersResult.IsSucceeded ? ordersResult.Data : new List<OrderViewModel>();

            var cartResult = await CartService.GetCartAsync(userId);
            if (cartResult.IsSucceeded)
            {
                ViewBag.CountOfItems = cartResult.Data.CountOfItem;
            }
            else
            {
                _notyfService.Error(cartResult.Error ?? "Sepet bilgisi alınamadı.");
                return Redirect("~/");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                _notyfService.Error("Böyle bir kullanıcı yok!");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                _notyfService.Warning("Email onaylı değil!");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
            if (!result.Succeeded)
            {
                _notyfService.Error("Hatalı kullanıcı adı veya parola!");
                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "~/");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public async Task<IActionResult> UpdateProfile(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Geçersiz bilgiler!");
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
                _notyfService.Error(result.Errors.FirstOrDefault()?.Description ?? "Güncelleme hatası!");
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrWhiteSpace(model.CurrentPassword) && !string.IsNullOrWhiteSpace(model.NewPassword))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    _notyfService.Error(passwordChangeResult.Errors.FirstOrDefault()?.Description ?? "Parola değişikliği başarısız!");
                    return RedirectToAction("Index");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            _notyfService.Success("Profil başarıyla güncellendi!");
            return RedirectToAction("Index");
        }

        // Diğer metotlar aynı mantıkla düzenlenebilir.
    }
}