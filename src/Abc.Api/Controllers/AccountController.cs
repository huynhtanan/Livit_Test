using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abc.Service.Services;
using Abc.ApiContract.Arguments;
using Abc.ApiContract.Results;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Abc.Api.Controllers
{
	public class AccountController : Controller
	{
		private IAccountService _accountService;
		public AccountController(IAccountService ab)
		{
			this._accountService = ab;
		}
		
		public IActionResult Login([FromBody]LoginArgument arg)
		{
			try
			{
				var result = _accountService.Login(arg);
				return Json(_accountService.Login(arg));
			}
			catch(Exception ex)
			{
				return Json(new LoginResult { Status = "Error", ErrorMessage = ex.Message });
			}
		}		
	}
}
