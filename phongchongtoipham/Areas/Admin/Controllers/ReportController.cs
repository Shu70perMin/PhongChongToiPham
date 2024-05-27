using Microsoft.AspNetCore.Mvc;
using phongchongtoipham.Controllers;
using phongchongtoipham.Models;

namespace phongchongtoipham.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        PctpdbContext db = new PctpdbContext();
        private readonly ILogger<HomeController> _logger;

        public ReportController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Accept(int id, string name, string type, DateOnly date, string location, string status, IFormFile image)
        {
            var p = new CrimeList();
            var x = await db.Reports.FindAsync(id);
            p.Id = x.Id;
            p.Image = x.Image;
            p.Name = x.Name;
            p.Type = x.Type;
            p.Date = x.Date;
            p.Location = x.Location;
            p.Status = "Chưa tóm";
            try
            {
                db.CrimeLists.Add(p);
            }
            catch
            {
                p.Id += 999;
                db.CrimeLists.Add(p);
            }
            db.Reports.Remove(x);
            await db.SaveChangesAsync();
            return RedirectToAction("ReportManagement", "Admin", new { area = "Admin" });
        }
        
        [HttpPost]
        public async Task<IActionResult> Reject(int id)
        {
            var p = await db.Reports.FindAsync(id);
            if (p != null)
            {
                db.Reports.Remove(p);
            }
            await db.SaveChangesAsync();
            return RedirectToAction("ReportManagement", "Admin", new { area = "Admin" });
        }
    }
}
