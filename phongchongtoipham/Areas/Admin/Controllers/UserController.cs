using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using phongchongtoipham.Controllers;
using phongchongtoipham.Models;

namespace phongchongtoipham.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        PctpdbContext db = new PctpdbContext();
        private readonly ILogger<HomeController> _logger;

        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public JsonResult Add(string username, string fullname, string email, string phone, string password1,string password2, string role)
        {
            if (password1 != password2)
                return Json(new { Message = "Vui lòng nhập mật khẩu giống nhau" });
            var p = new User();
            p.UserName = username;
            p.FullName = fullname;
            p.Email = email;
            p.Phone = phone;
            p.Password = password1;
            int r;
            if (role == "admin") r = 99;
                else r = 1;
            p.Role = r;
            try
            {
                db.Users.Add(p);
                db.SaveChanges();
            }
            catch
            {
                return Json(new { Message = "Tài khoản đã tồn tại" });
            }
            return Json(new { Message = "Thêm tài khoản thành công" });
        }
        [HttpPost]
        public async Task<JsonResult> Edit(string username, string fullname, string email, string phone, string password, string role)
        {
            var p = await db.Users.FindAsync(username);
            if (p == null) return Json(new { Messagem = "bucac roi" });
            p.FullName = fullname;
            p.Email = email;
            p.Phone = phone;
            p.Password = password;
            if (role == "Admin")
            {
                p.Role = 99;
            }
            else p.Role = 1;
            await db.SaveChangesAsync();
            return Json(new { Message = "Sửa tài khoản thành công" });
        }
        [HttpPost]
        public async Task<IActionResult> Remove(string username)
        {
            var p = await db.Users.FindAsync(username);
            if (p != null)
            {
                db.Users.Remove(p);
            }
            await db.SaveChangesAsync();
            return RedirectToAction("UserManagement", "Admin", new { area = "Admin" });
        }
    }
}
