using System;

namespace Abc.ApiContract.Arguments
{
	public class AbsenceCreateArgument
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int AbsenceTypeId { get; set; }
		public string Comments { get; set; }
		public int NumberOfDays { get; set; }
		public int EmployeeId { get; set; }
		public string UnvalidatedComments { get; set; }
		public int AbsenceStateId { get; set; }
		public int CreatedById { get; set; }
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
