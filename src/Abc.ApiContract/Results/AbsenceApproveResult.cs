using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.ApiContract.Results
{
	public class AbsenceApproveResult:Result
	{
		public int AbsenceId { get; set; }
		public string AbsenceState { get; set; }
	}
}
