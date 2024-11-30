using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EgeApp.Frontend.Mvc.Data.Entities;
using EgeApp.Frontend.Mvc.Models.Identity;

namespace EgeApp.Frontend.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Super Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly INotyfService _notyfService;

        public RoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, INotyfService notyfService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [NonAction]
        public async Task<RoleAssignViewModel> InitializeUsers(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var users = await _userManager.Users.ToListAsync();
            List<AppUser> members = [];
            List<AppUser> nonMembers = [];
            foreach (var user in users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)
                            ? members
                            : nonMembers;
                list.Add(user);
            }
            RoleAssignViewModel model = new()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return model;
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await InitializeUsers(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleAssignViewModel model)
        {
            // RoleId'nin eksikliğini kontrol et
            if (string.IsNullOrEmpty(model.RoleId))
            {
                _notyfService.Error("Rol ID'si eksik veya gönderilmedi.");
                return RedirectToAction("Index");
            }

            // RoleManager üzerinden rolü yükle
            model.Role = await _roleManager.FindByIdAsync(model.RoleId);
            if (model.Role == null)
            {
                _notyfService.Error($"Rol bulunamadı. RoleId: {model.RoleId}");
                return RedirectToAction("Index");
            }

            // Kullanıcıları role ekleme
            foreach (var userId in model.IdsAdd ?? new List<string>())
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _notyfService.Error($"Kullanıcı bulunamadı: {userId}");
                    continue;
                }

                var result = await _userManager.AddToRoleAsync(user, model.Role.Name);
                if (!result.Succeeded)
                {
                    _notyfService.Error(result.Errors.FirstOrDefault()?.Description ?? "Bilinmeyen bir hata oluştu.");
                    return View(await InitializeUsers(model.RoleId));
                }
            }

            // Kullanıcıları rolden çıkarma
            foreach (var userId in model.IdsRemove ?? new List<string>())
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _notyfService.Error($"Kullanıcı bulunamadı: {userId}");
                    continue;
                }

                var result = await _userManager.RemoveFromRoleAsync(user, model.Role.Name);
                if (!result.Succeeded)
                {
                    _notyfService.Error(result.Errors.FirstOrDefault()?.Description ?? "Bilinmeyen bir hata oluştu.");
                    return View(await InitializeUsers(model.RoleId));
                }
            }

            _notyfService.Success("Rol/Kullanıcı Atama değişiklikleri başarıyla uygulandı!");
            return RedirectToAction("Index");
        }
    }
}