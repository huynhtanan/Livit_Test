using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.ApiContract.Arguments;
using Abc.ApiContract.Results;
using Abc.Dal.Models;

namespace Abc.Service.Services
{
	public interface IAbsenceService
	{
		AbsenceCreateResult Create(AbsenceCreateArgument arg);
		AbsenceApproveResult Approve(AbsenceApproveArgument arg);
		Absence GetAbsenceById(int id);
	}
}
