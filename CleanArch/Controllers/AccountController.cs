using CleanArch.Application.Enums;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Tools;
using CleanArch.Application.ViewModels.Account;
using CleanArch.Domain.Models.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArch.Controllers
{
	public class AccountController : Controller
	{
		private IUserService _userService;

		public AccountController(IUserService userService)
		{
			_userService = userService;
		}

		#region Register
		[Route("Register")]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[Route("Register")]
		public IActionResult Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var checkUserName = _userService.CheckUserName(model.UserName);

			if (checkUserName != CheckUser.OK)
			{
				ViewBag.Check = checkUserName;
				return View(model);
			}

			var checkEmail = _userService.CheckEmail(model.Email);

			if (checkEmail != CheckUser.OK)
			{
				ViewBag.Check = checkEmail;
				return View(model);
			}

			var newUser = new User
			{
				Email = model.Email.Trim().ToLower(),
				Password = SecurityUtils.EncodePasswordMd5(model.Password),
				UserName = model.UserName,
			};

			var userId = _userService.RegisterUser(newUser);
			if (userId > 0)
				return View("SuccessRegister", model);

			return View(model);
		}
		#endregion

		#region Login
		[Route("Login")]
		public IActionResult Login(string returnUrl = "/")
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[HttpPost]
		[Route("Login")]
		public IActionResult Login(LoginViewModel model, string returnUrl = "/")
		{
			if (!ModelState.IsValid)
				return View(model);

			var isExistUser = _userService.IsExistUser(model.Email, model.Password);

			if (!isExistUser)
			{
				ModelState.AddModelError("Email", "User not found ...");
				return View(model);
			}


			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Email, model.Email),
				new Claim(ClaimTypes.NameIdentifier, model.Email),
			};

			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			var principal = new ClaimsPrincipal(identity);
			var properties = new AuthenticationProperties() { IsPersistent = model.RememberMe };

			HttpContext.SignInAsync(principal, properties);

			return Redirect(returnUrl);
		}
		#endregion

		#region Logout
		[Authorize]
		public IActionResult Logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return Redirect("/");
		}
		#endregion

	}
}
