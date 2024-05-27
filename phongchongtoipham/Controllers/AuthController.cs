using Microsoft.AspNetCore.Mvc;
using phongchongtoipham.Models;

namespace phongchongtoipham.Controllers
{
    public class AuthController : Controller
    {
        PctpdbContext db = new PctpdbContext();
        private readonly ILogger<HomeController> _logger;

        public AuthController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SignupRequest(string username, string fullname, string email, string phone, string pass1, string pass2)
        {
            var p = new User();
            if (pass1 != pass2)
            {
                return Json(new { Message = "Vui lòng nhập mật khẩu giống nhau" });
            }
            p.UserName = username;
            p.FullName = fullname;
            p.Email = email;
            p.Phone = phone;
            p.Password = pass1;
            p.Role = 1;
            try
            {
                db.Users.Add(p);
                db.SaveChanges();
            }
            catch
            {
                return Json(new { Message = "Tên tài khoản đã tồn tại" });
            }
            return Json(new { RedirectUrl = Url.Action("Login", "Auth") });
            /*return Json(new { Message = "Tạo tài khoản thành công" });*/
        }
		public IActionResult Login()
		{
			if (HttpContext.Session.GetString("UserName") == null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
		[HttpPost]
		public JsonResult LoginRequest(string username, string password)
		{
			if (HttpContext.Session.GetString("UserName") == null)
			{
				var u = db.Users.Where(x => x.UserName.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
				if (u != null)
				{
					HttpContext.Session.SetString("UserName", username.ToString());
					/*if (u.Role == 99)
						return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });*/
					return Json(new { RedirectUrl = Url.Action("Index", "Home") });
				}
			}
			return Json(new { Message = "Tên tài khoản hoặc mật khẩu sai" });
		}
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }
	}
}
