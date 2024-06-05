using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using phongchongtoipham.Controllers;
using phongchongtoipham.Models;
using WebSiteShopping.Models;

namespace phongchongtoipham.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    public class AdminController : Controller
    {
        PctpdbContext db = new PctpdbContext();
        private readonly ILogger<HomeController> _logger;

        public AdminController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("ReportManagement")]
        [Authentication]
        public IActionResult ReportManagement()
        {
            var list = from p in db.Reports
                       select p;
            return View(list);
        }
        [Route("CrimeManagement")]
        [Authentication]
        public IActionResult CrimeManagement() 
        {
            var list = from p in db.CrimeLists
                       select p;
            return View(list);
        }
        [Route("UserManagement")]
        [Authentication]
        public IActionResult UserManagement()
        {
            var list = from p in db.Users
                       select p;
            return View(list);
        }
        [Route("PostManagement")]
        [Authentication]
        public IActionResult PostManagement()
        {
            return View();
        }

    }
}
