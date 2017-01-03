using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Dal.Models
{
	public class Absence : BaseEntity
	{
		public int AbsenceId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int AbsenceTypeId { get; set; }
		public virtual AbsenceType AbsenceType { get; set; }
		public string Comments { get; set; }
		public int NumberOfDays { get; set; }
		public int? ValidatedById { get; set; }
		public virtual Employee ValidatedBy { get; set; }
		public DateTime? ValidatedDate { get; set; }
		public bool? IsDeleted { get; set; }
		public int EmployeeId { get; set; }
		public virtual Employee Employee { get; set; }
		public string UnvalidatedComments { get; set; }
		public int AbsenceStateId { get; set; }
		public virtual AbsenceState AbsenceState { get; set; }
		public string Summary { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string StartTimeZone { get; set; }
		public string EndTimeZone { get; set; }
		public string Recurrence { get; set; }
		public string AttendeeEmails { get; set; }
		public string ReminderMethods { get; set; }
	}
}
