using FoodOrder.Entity.Entities;
using FoodOrder.WebUI.Dtos.IdentityDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(loginDto.Username,loginDto.Password,false,false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Statistics");
			}
			return View();
		}
	}
}
