using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Dal.Models
{
	public interface IBaseEntity
	{
		DateTime? CreatedDate { get; set; }

		int? CreatedById { get; set; }
		Employee CreatedBy { get; set; }

		DateTime? UpdatedDate { get; set; }

		int? UpdatedById { get; set; }
		Employee UpdatedBy { get; set; }
	}
}
