using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Api.ViewModels
{
	public class AbsenceCalendarViewModel
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
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
