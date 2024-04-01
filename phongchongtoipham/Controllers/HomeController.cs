using Microsoft.AspNetCore.Mvc;

namespace phongchongtoipham.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult data()
        {
            return View();
        }

        public IActionResult KiemTraKienThuc()
        {
            return View();
        }

        public IActionResult KienThuc()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }
    }


}
