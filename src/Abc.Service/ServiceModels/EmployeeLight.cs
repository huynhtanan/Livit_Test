using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Service.ServiceModels
{
	public class EmployeeLight
	{
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName => LastName + " " + FirstName;
		public string Email { get; set; }
		public string EmployeeStatus { get; set; }
		public string EmployeeType { get; set; }
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public string GoogleApiUserId { get; set; }
		public string Code { get; set; }
	}
}
