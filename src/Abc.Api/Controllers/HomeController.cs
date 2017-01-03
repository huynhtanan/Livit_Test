using Microsoft.AspNetCore.Mvc;
using Abc.Api.GoogleHelpers;
using Abc.ApiContract.Arguments;
using Abc.ApiContract.Results;
using Abc.Service.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Abc.Api.Controllers
{
	public class HomeController : BaseController
	{
		public HomeController(IAccountService accountService) : base(accountService)
		{
		}
		public IActionResult Index()
		{
			if (AccountService.LoggedEmployee != null && APIHelper.GetUserInfo(AccountService.LoggedEmployee.AccessToken).id != null)
				return RedirectToAction("Confirmation", new { code = AccountService.LoggedEmployee.Code });

			return View();
		}

		public IActionResult Confirmation(string code)
		{
			if (AccountService.LoggedEmployee != null && APIHelper.GetUserInfo(AccountService.LoggedEmployee.AccessToken).id != null)
				return View();
			var redirectUrl = Url.Action("Confirmation", "Home", null, Request.Scheme, null);
			var apiToken = APIHelper.GetAccessToken(redirectUrl, code);
			if (apiToken.access_token != null)
			{
				var user = APIHelper.GetUserInfo(apiToken.access_token);
				var loginArg = new LoginArgument
				{
					Email = user.email,
					FirstName = user.given_name,
					LastName = user.family_name
				};
				AccountService.Login(loginArg);
				AccountService.SetToken(apiToken.access_token, apiToken.refresh_token, code, user.id);

				return View();
			}
			else
				return RedirectToAction("Index");
		}
	}
}
