using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Abc.Dal.Models;
using Abc.Service.Services;
using Abc.Api.GoogleHelpers;

namespace Abc.Api.Controllers
{
	public class BaseController : Controller
	{
		private IAccountService _accountService;
		
		public IAccountService AccountService
		{
			get
			{
				return _accountService;
			}

			set
			{
				_accountService = value;
			}
		}

		public BaseController(IAccountService accountService)
		{
			this.AccountService = accountService;
		}
		public bool IsAdmin
		{
			get
			{
				return AccountService.IsAdmin(AccountService.LoggedEmployee.EmployeeId);
			}
		}
	}
}
