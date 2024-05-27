using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using phongchongtoipham.Models;
using X.PagedList;

namespace phongchongtoipham.Controllers
{
    public class HomeController : Controller
    {
        PctpdbContext db = new PctpdbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult data(int? page, string? name)
        {
            int pageSize = 10;
            int pageNumber = page == null||page<0?1:page.Value;
            if (name != null)
            {
                var data = db.CrimeLists.Where(x => x.Name == name).AsNoTracking().OrderBy(x => x.Name);
                PagedList<CrimeList> list = new PagedList<CrimeList>(data, pageNumber, pageSize);
                return View(list);
            }
            else
            {
                var data = db.CrimeLists.AsNoTracking().OrderBy(x => x.Name);
                PagedList<CrimeList> list = new PagedList<CrimeList>(data, pageNumber, pageSize);
                return View(list);
            }
        }

        public IActionResult KiemTraKienThuc()
        {
            return View();
        }

        public IActionResult KienThuc()
        {
            return View();
        }

        public IActionResult quiz()
        {
            return View();
        }

        public IActionResult Blog()
        {
            var list = from p in db.Blogs
                       select p;
            return View(list);
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult ctbv(string title)
        {
            var x = from p in db.Blogs
                    where p.Title == title
                    select p;
            return View(x);
        }
        public IActionResult Report()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> ReportRequest(string name, string type,DateOnly date, string location, string detail, IFormFile image)
        {
            var p = new Report();
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "crimeImg", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                p.Image = fileName;
            }
            p.Name = name;
            p.Type = type;
            p.Date = date;
            p.Location = location;
            p.Detail = detail;
            try
            {
                db.Reports.Add(p);
                await db.SaveChangesAsync();
            }
            catch
            {
                return Json(new { Message = "Báo cáo thất bại" });
            }
            return Json(new { Message = "Báo cáo thành công" });
        }


    }
}
