using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Dal.Models;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Abc.ApiContract.Arguments;
using Abc.ApiContract.Results;
using Abc.Service.ServiceModels;
using AutoMapper;

namespace Abc.Service.Services
{
	public class AccountService : IAccountService
	{
		private IMapper _mapper;
		private IEntityService<Employee> _employeeService;
		private IEntityService<Employee_Role> _employeeRoleService;
		private EmployeeLight _loggedEmployee;
		public AccountService(IEntityService<Employee> employeeService, IEntityService<Employee_Role> employeeRoleService, IMapper mapper)
		{
			this._employeeService = employeeService;
			this._employeeRoleService = employeeRoleService;
			this._mapper = mapper;
		}
		public EmployeeLight LoggedEmployee
		{
			get
			{
				return this._loggedEmployee;
			}
			set
			{
				this._loggedEmployee = value;
			}
		}
		public bool IsAdmin(int employeeId)
		{
			return _employeeRoleService.Get(x => x.EmployeeId == employeeId && x.RoleId == (int)Enums.Role.Admin).Any();
		}
		public bool EmailIsExisted(string email)
		{
			return _employeeService.Get(x => x.Email == email).Any();
		}
		public IQueryable<EmployeeLight> GetEmployeeByEmail(string email)
		{
			return _employeeService.Get(x => x.Email == email).Select(x => new EmployeeLight
			{
				EmployeeId = x.EmployeeId,
				Email = x.Email,
				FirstName = x.FirstName,
				LastName = x.LastName,
				EmployeeStatus = x.EmployeeStatus.Label,
				EmployeeType = x.EmployeeType.Label
			});
		}
		public LoginResult Login(LoginArgument arg)
		{
			try
			{
				if (!EmailIsExisted(arg.Email))
				{
					var employee = _mapper.Map<Employee>(arg);
					_employeeService.Create(employee);
					_employeeService.Save();
				}

				var emp = GetEmployeeByEmail(arg.Email);
				_loggedEmployee = emp.FirstOrDefault();
				return emp.Select(x => new LoginResult { Email = x.Email, EmployeeType = x.EmployeeType, EmployeeStatus = x.EmployeeStatus, Status = "Success" }).FirstOrDefault();
			}
			catch (Exception ex)
			{
				return new LoginResult { Status = "Error", ErrorMessage = "Error occured when login. " + ex.Message };
			}
		}
		public void SetToken(string accessToken, string refreshToken, string code, string userId)
		{
			this.LoggedEmployee.AccessToken = accessToken;
			this.LoggedEmployee.RefreshToken = refreshToken;
			this.LoggedEmployee.Code = code;
			this.LoggedEmployee.GoogleApiUserId = userId;
		}
		//private bool LoginWithGmail(LoginArgument arg)
		//{
		//	try
		//	{
		//		using (var client = new SmtpClient())
		//		{
		//			// For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
		//			client.ServerCertificateValidationCallback = (s, c, h, e) => true;

		//			client.Connect("smtp.gmail.com", 587, false);

		//			// Note: since we don't have an OAuth2 token, disable
		//			// the XOAUTH2 authentication mechanism.
		//			client.AuthenticationMechanisms.Remove("XOAUTH2");

		//			// Note: only needed if the SMTP server requires authentication
		//			client.Authenticate(arg.UserName, arg.Password);

		//			client.Disconnect(true);
		//		}
		//		return true;
		//	}
		//	catch {
		//		return false;
		//	}
		//}
	}
}
