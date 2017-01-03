using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Dal.Models;
using Abc.ApiContract.Results;
using Abc.ApiContract.Arguments;
using Abc.Service.ServiceModels;

namespace Abc.Service.Services
{
	public interface IAccountService
	{
		EmployeeLight LoggedEmployee { get; set; }
		bool EmailIsExisted(string email);
		LoginResult Login(LoginArgument arg);
		bool IsAdmin(int employeeId);
		void SetToken(string accessToken, string refreshToken, string code, string userId);
	}
}
