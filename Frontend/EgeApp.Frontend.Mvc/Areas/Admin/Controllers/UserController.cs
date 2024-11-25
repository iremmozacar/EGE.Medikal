using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EgeApp.Frontend.Mvc.Data.Entities;
using EgeApp.Frontend.Mvc.Models.Identity;
using EgeApp.Frontend.Mvc.Services;

namespace EgeApp.Frontend.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Super Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly INotyfService _notyfService;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, INotyfService notyfService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var model = new UpdateUserProfileViewModel
            {
                UserId = id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = await _roleManager.Roles.ToListAsync(),
                UserRoles = (await _userManager.GetRolesAsync(user)).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserProfileViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (!ModelState.IsValid)
            {
                model.Roles = await _roleManager.Roles.ToListAsync();
                model.UserRoles = [];
                ViewBag.ErrorRoleMessage = "En az bir kategori seçmelisiniz.";
                return View(model);
            }
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);

            //Kullanıcının halihazırdaki veritabanında yer alan rollerini alıyoruz.
            var currentUserRoles = await _userManager.GetRolesAsync(user);

            //Modelden gelen UserRoles içindeki YENİ rolleri, kullanıcının geçerli rolleri hariç ekle.
            await _userManager.AddToRolesAsync(user, model.UserRoles.Except(currentUserRoles));

            //Modelden gelen UserRoles içindeki SİLİNEN rolleri, kullanıcının veri tabanındaki var olan rollerinden sil
            await _userManager.RemoveFromRolesAsync(user, currentUserRoles.Except(model.UserRoles));

            _notyfService.Success("Güncelleme işlemi başarıyla tamamlanmıştır.");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ConfirmEmail(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.EmailConfirmed = !user.EmailConfirmed;
            await _userManager.UpdateAsync(user);
            await CartService.InitiliazeCartAsync(user.Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            var model = new CreateUserProfileViewModel
            {
                Roles = await _roleManager.Roles.ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Roles = await _roleManager.Roles.ToListAsync();
                model.UserRoles = [];
                ViewBag.ErrorRoleMessage = "En az bir kategori seçmelisiniz.";
                return View(model);
            }
            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, model.UserRoles);
                _notyfService.Success("Kullanıcı başarıyla oluşturulmuştur");
                return RedirectToAction("Index");
            }
            model.Roles = await _roleManager.Roles.ToListAsync();
            _notyfService.Error("Bir sorun oluştu");
            return View(model);
        }
    }
}
