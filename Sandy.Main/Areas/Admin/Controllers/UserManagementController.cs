using Microsoft.AspNetCore.Mvc;
using Sandy.Main.Controllers;

namespace Sandy.Main.Areas.Admin.Controllers
{
    public class UserManagementController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
