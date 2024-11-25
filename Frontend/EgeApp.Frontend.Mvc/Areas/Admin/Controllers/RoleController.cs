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
            model.Role = await _roleManager.FindByIdAsync(model.RoleId);
            //İlgili role seçilen kullanıcıları ekliyoruz
            foreach (var userId in model.IdsAdd ?? [])
            {
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.AddToRoleAsync(user, model.Role.Name);
                if (!result.Succeeded)
                {
                    _notyfService.Error(result.Errors.ToList()[0].Description);
                    var resultModel = await InitializeUsers(model.RoleId);
                    resultModel.IdsAdd = model.IdsAdd;
                    resultModel.IdsRemove = model.IdsRemove;
                    return View(resultModel);
                }
            }
            //İlgili rolden çıkarılan kullanıcıları siliyoruz
            foreach (var userId in model.IdsRemove ?? [])
            {
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.RemoveFromRoleAsync(user, model.Role.Name);
                if (!result.Succeeded)
                {
                    _notyfService.Error(result.Errors.ToList()[0].Description);
                    var resultModel2 = await InitializeUsers(model.RoleId);
                    resultModel2.IdsAdd = model.IdsAdd;
                    resultModel2.IdsRemove = model.IdsRemove;
                    return View(resultModel2);
                }
            }
            _notyfService.Success("Rol/Kullanıcı Atama değişiklikleri başarıyla uygulandı!");
            var resultModel3 = await InitializeUsers(model.RoleId);
            return View(resultModel3);
        }
    }
}
