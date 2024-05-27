using Microsoft.AspNetCore.Mvc;
using phongchongtoipham.Controllers;
using phongchongtoipham.Models;
using Microsoft.EntityFrameworkCore;


namespace phongchongtoipham.Areas.Admin.Controllers
{
     public class CrimeController : Controller
    {
        PctpdbContext db = new PctpdbContext();
        private readonly ILogger<HomeController> _logger;

        public CrimeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<JsonResult> Add(int id, string name, string type,DateOnly date,string location, string status, IFormFile image)
        {
            var p = new CrimeList();
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
            p.Id = id;
            p.Name = name;
            p.Type = type;
            p.Date = date;
            p.Location = location;
            p.Status = status;
            try
            {
                db.CrimeLists.Add(p);
                await db.SaveChangesAsync();
            }
            catch
            {
                return Json(new { Message = "ID tội phạm đã tồn tại" });
            }
            return Json(new { Message = "Thêm tội phạm thành công" });
        }
        [HttpPost]
        public async Task<JsonResult> Edit(int id, string name, string type, DateOnly date, string location, string status, IFormFile image)
        {
            var p = await db.CrimeLists.FindAsync(id);
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "crimeImg", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                if (!string.IsNullOrEmpty(p.Image))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "crimeImg", p.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                p.Image = fileName;
            }
            p.Name = name;
            p.Type = type;
            p.Date = date;
            p.Location = location;
            p.Status = status;

            await db.SaveChangesAsync();

            return Json(new { Message = "Sửa tội phạm thành công" });
        }
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var p = await db.CrimeLists.FindAsync(id);
            if (p.Image != null)
            {
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "crimeImg", p.Image);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            if (p != null)
            {
                db.CrimeLists.Remove(p);
            }
            await db.SaveChangesAsync();
            return RedirectToAction("CrimeManagement", "Admin", new { area = "Admin" });
        }
    }
}
