using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.Dal.Models
{
	public class Employee : BaseEntity
	{
		public int EmployeeId { get; set; }
		[Display(Name = "Email")]
		public string Email { get; set; }
		[Display(Name = "User name")]
		public string UserName { get; set; }
		[Display(Name = "First name")]
		public string FirstName { get; set; }
		[Display(Name = "Last name")]
		public string LastName { get; set; }
		public DateTime? EntryDate { get; set; }
		public DateTime? ExitDate { get; set; }
		public int EmployeeStatusId { get; set; }
		public virtual EmployeeStatus EmployeeStatus { get; set; }
		public int EmployeeTypeId { get; set; }
		public virtual EmployeeType EmployeeType { get; set; }
		public bool? IsDeleted { get; set; }
	}
}
