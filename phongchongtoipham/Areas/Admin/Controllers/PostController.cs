using Microsoft.AspNetCore.Mvc;
using phongchongtoipham.Controllers;
using phongchongtoipham.Models;

namespace phongchongtoipham.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        PctpdbContext db = new PctpdbContext();
        private readonly ILogger<HomeController> _logger;

        public PostController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public JsonResult PostRequest(string title, string c1, string c2, string c3, IFormFile image)
        {
            var p = new Blog();
            
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "blogImg", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                p.Image = fileName;
            }
            p.Title = title;
            p.Content1 = c1;
            p.Content2 = c2;
            p.Content3 = c3;
            db.Blogs.Add(p);
            db.SaveChanges();
            return Json(new { Message = "Thành công" });
        }
    }
}
