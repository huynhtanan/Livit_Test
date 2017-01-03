using System;
using System.ComponentModel.DataAnnotations;

namespace Abc.Dal.Models
{
	public abstract class BaseEntity : IBaseEntity
	{
		[ScaffoldColumn(false)]
		public DateTime? CreatedDate { get; set; }

		[ScaffoldColumn(false)]
		public int? CreatedById { get; set; }

		[ScaffoldColumn(false)]
		public virtual Employee CreatedBy { get; set; }

		[ScaffoldColumn(false)]
		public DateTime? UpdatedDate { get; set; }

		[ScaffoldColumn(false)]
		public int? UpdatedById { get; set; }

		[ScaffoldColumn(false)]
		public virtual Employee UpdatedBy { get; set; }
	}
}
