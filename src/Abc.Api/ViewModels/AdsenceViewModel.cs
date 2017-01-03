using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Api.ViewModels
{
	public class AdsenceViewModel
	{
		public int AbsenceId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int AbsenceTypeId { get; set; }
		public string Comments { get; set; }
		public int NumberOfDays { get; set; }
		public int ValidatedById { get; set; }
		public DateTime? ValidatedDate { get; set; }
		public bool IsDeleted { get; set; }
		public int EmployeeId { get; set; }
		public string UnvalidatedComments { get; set; }
		public int AbsenceStateId { get; set; }
	}
}
