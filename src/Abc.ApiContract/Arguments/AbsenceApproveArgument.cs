using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.ApiContract.Arguments
{
	public class AbsenceApproveArgument
	{
		public int AbsenceId { get; set; }
		public int UpdatedById { get; set; }
		public int AbsenceStateId { get; set; }
		public int ValidatedId { get; set; }
		public DateTime? ValidatedDate { get; set; }
	}
}
