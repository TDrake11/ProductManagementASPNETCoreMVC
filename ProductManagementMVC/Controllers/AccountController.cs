using Microsoft.AspNetCore.Mvc;
using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Services.Services.AccountService;

namespace PRN222.Lab1.ProductManagementMVC.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(AccountMember model)
		{
			AccountMember? user = _accountService.GetAccountMember(model.EmailAddress);

			if (user != null && user.MemberPassword == model.MemberPassword)
			{
				// Tạo Cookie để lưu thông tin đăng nhập
				var cookieOptions = new CookieOptions
				{
					Expires = DateTime.UtcNow.AddMinutes(15), // Cookie hết hạn sau 15p
					HttpOnly = true, // Chỉ có thể truy cập qua HTTP (bảo mật hơn, tránh JavaScript truy cập)
					Secure = true, // Chỉ truyền cookie qua HTTPS
					IsEssential = true // Cookie cần thiết cho ứng dụng
				};

				HttpContext.Response.Cookies.Append("UserId", user.MemberId.ToString(), cookieOptions);
				HttpContext.Response.Cookies.Append("Username", user.FullName, cookieOptions);

				return RedirectToAction("Index", "Products"); // Điều hướng sau khi đăng nhập thành công
			}
			else
			{
				ModelState.AddModelError("", "Invalid username or password.");
			}

			return View(model);
		}


		public IActionResult Logout()
		{
			HttpContext.Response.Cookies.Delete("UserId");
			HttpContext.Response.Cookies.Delete("Username");

			return RedirectToAction("Login");
		}

	}
}
