using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abc.Api.GoogleHelpers;
using Abc.Service.Services;

namespace Abc.Api.Controllers
{
	public class CalendarController : BaseController
	{
		public CalendarController(IAccountService accountService) : base(accountService)
		{
		}

		[HttpGet]
		public ActionResult GetCalendarList()
		{
			if (AccountService.LoggedEmployee == null)
				return Json("Not logged in.");
			if (APIHelper.GetUserInfo(AccountService.LoggedEmployee.AccessToken) == null)
				return Json("Not logged in.");
			var t = CalendarHelper.GetCalendarList(AccountService.LoggedEmployee.AccessToken, AccountService.LoggedEmployee.RefreshToken, AccountService.LoggedEmployee.GoogleApiUserId);
			return Json(t);
		}
	}
}
