using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Dal.Models
{
	public class Employee_Role : BaseEntity
	{
		public int Employee_RoleId { get; set; }
		public int EmployeeId { get; set; }
		public int RoleId { get; set; }
		public virtual Employee Employee { get; set; }
		public virtual Role Role { get; set; }

	}
}
