using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.ApiContract.Results
{
	public class LoginResult:Result
	{
		public string Email { get; set; }
		public string EmployeeType { get; set; }
		public string EmployeeStatus { get; set; }
	}
}
