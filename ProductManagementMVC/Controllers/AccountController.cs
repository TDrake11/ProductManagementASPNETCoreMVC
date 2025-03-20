using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Services.Services.AccountService;
using System.Security.Claims;

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
		public async Task<IActionResult> LoginAsync(AccountMember model)
		{
			AccountMember? user = _accountService.GetAccountMember(model.EmailAddress);

			if (user != null && user.MemberPassword == model.MemberPassword)
			{
				// Tạo danh sách Claims (dữ liệu nhận diện người dùng)
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, user.MemberId.ToString()),
					new Claim(ClaimTypes.Name, user.FullName),
					new Claim(ClaimTypes.Email, user.EmailAddress)
				};

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var authProperties = new AuthenticationProperties
				{
					IsPersistent = true, // Giữ trạng thái đăng nhập khi đóng trình duyệt
					ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(15) // Hết hạn sau 15 phút
				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity), authProperties);

				return RedirectToAction("Index", "Products");
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
