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
				// Store user information in session
				HttpContext.Session.SetString("UserId", user.MemberId);
				HttpContext.Session.SetString("Username", user.FullName);

				return RedirectToAction("Index", "Products"); // Redirect to home page
			}
			else
			{
				ModelState.AddModelError("", "Invalid username or password.");
			}


			return View(model);
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear(); // Clear session data
			return RedirectToAction("Login");
		}
	}
}
