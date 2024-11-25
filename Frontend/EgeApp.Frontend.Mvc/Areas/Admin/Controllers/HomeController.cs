using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgeApp.Frontend.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Super Admin, Admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
