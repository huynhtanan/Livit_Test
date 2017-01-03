using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Dal.Models;
using AutoMapper;
using Abc.ApiContract.Arguments;
using Abc.ApiContract.Results;

namespace Abc.Service.Services
{
	public class AbsenceService : IAbsenceService
	{
		private IMapper _mapper;
		private IEntityService<Absence> _absenceService;

		public AbsenceService(IEntityService<Absence> absenceService, IMapper mapper)
		{
			this._absenceService = absenceService;
			this._mapper = mapper;
		}
		public AbsenceCreateResult Create(AbsenceCreateArgument arg)
		{
			var ab = _mapper.Map<Absence>(arg);

			_absenceService.Create(ab);
			_absenceService.Save();

			return _mapper.Map<AbsenceCreateResult>(ab);
		}
		public AbsenceApproveResult Approve(AbsenceApproveArgument arg)
		{
			var ab = _absenceService.Get(x => x.AbsenceId == arg.AbsenceId, includeProperties: "AbsenceState").FirstOrDefault();
			ab.UpdatedById = arg.UpdatedById;
			ab.AbsenceStateId = arg.AbsenceStateId;
			ab.ValidatedById = arg.ValidatedId;
			ab.ValidatedDate = arg.ValidatedDate;

			_absenceService.Update(ab);
			_absenceService.Save();

			return new AbsenceApproveResult { AbsenceId = ab.AbsenceId, AbsenceState = ab.AbsenceState.Label };
		}
		public Absence GetAbsenceById(int id)
		{
			return _absenceService.Get(x => x.AbsenceId == id).FirstOrDefault();
		}
	}
}
