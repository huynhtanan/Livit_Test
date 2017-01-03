using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abc.Service.Services;
using Newtonsoft.Json;
using Abc.ApiContract.Arguments;
using Abc.ApiContract.Results;
using Abc.Dal.Models;
using AutoMapper;
using Abc.Api.GoogleHelpers;
using Abc.Api.ViewModels;
using Swashbuckle.SwaggerGen.Annotations;
using Abc.Service.Enums;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Abc.Api.Controllers
{
	public class AbsenceController : BaseController
	{
		private IMapper _mapper;
		private IAbsenceService _absenceService;
		public AbsenceController(IAbsenceService absenceService, IAccountService accountService, IMapper mapper) : base(accountService)
		{
			this._absenceService = absenceService;
			this._mapper = mapper;
		}

		[HttpGet]
		public ActionResult Test()
		{
			try
			{

				if (AccountService.LoggedEmployee == null)
					return Json("Not logged in.");
				if (APIHelper.GetUserInfo(AccountService.LoggedEmployee.AccessToken).id == null)
					return Json("Not logged in.");
				return Json(AccountService.LoggedEmployee);
			}
			catch(Exception ex)
			{
				return Json(new { Error = "Error. " + ex.Message });
			}
		}
		[HttpPost]
		public ActionResult Create([FromBody] AbsenceCreateArgument arg)
		{
			try
			{
				if (AccountService.LoggedEmployee == null)
					return Json("Not logged in.");
				if (APIHelper.GetUserInfo(AccountService.LoggedEmployee.AccessToken).id == null)
					return Json("Not logged in.");

				arg.CreatedById = AccountService.LoggedEmployee.EmployeeId;
				arg.AbsenceStateId = (int)Service.Enums.AbsenceState.Sent_For_Validation;
				var result = _absenceService.Create(arg);
				
				return Json(result);
			}
			catch (Exception ex)
			{
				return Json(new AbsenceCreateResult { Status = "Error", ErrorMessage = ex.Message });
			}
		}
		[HttpPost]
		public ActionResult Approve([FromBody] AbsenceApproveArgument arg)
		{
			try
			{
				if (AccountService.LoggedEmployee == null)
					return Json("Not logged in.");
				if (APIHelper.GetUserInfo(AccountService.LoggedEmployee.AccessToken).id == null)
					return Json("Not logged in.");
				if (!IsAdmin)
					return Json("Not have permission.");

				arg.UpdatedById = AccountService.LoggedEmployee.EmployeeId;
				arg.ValidatedId = AccountService.LoggedEmployee.EmployeeId;
				arg.ValidatedDate = DateTime.Now;
				
				var result = _absenceService.Approve(arg);

				if (arg.AbsenceStateId == (int)Service.Enums.AbsenceState.Validated)
				{
					var absence = _absenceService.GetAbsenceById(arg.AbsenceId);
					var abCalendar = _mapper.Map<AbsenceCalendarViewModel>(absence);
					var t = CalendarHelper.InsertEvent(abCalendar, AccountService.LoggedEmployee.AccessToken, AccountService.LoggedEmployee.RefreshToken, AccountService.LoggedEmployee.GoogleApiUserId);
				}
				return Json(result);
			}
			catch(Exception ex)
			{
				return Json(new AbsenceApproveResult { Status = "Error", ErrorMessage = ex.Message });
			}
		}
	}
}
