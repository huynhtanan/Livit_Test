using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Abc.Dal.Models;
using Abc.ApiContract.Arguments;
using Abc.ApiContract.Results;
using Abc.Api.ViewModels;

namespace Abc.Api.Mappings
{
	public class AutoMapperConfiguration:Profile
	{
		protected override void Configure()
		{
			//calendar event
			CreateMap<AbsenceCalendarViewModel, Absence>();
			CreateMap<Absence, AbsenceCalendarViewModel>();
			//login
			CreateMap<Employee, LoginArgument>();
			CreateMap<LoginArgument, Employee>()
				.ForMember(e => e.EmployeeStatusId, opt => opt.UseValue<int>(1))
				.ForMember(e => e.EmployeeTypeId, opt => opt.UseValue<int>(1));
			//create
			CreateMap<Absence, AbsenceCreateArgument>();
			CreateMap<AbsenceCreateArgument, Absence>();
			CreateMap<AbsenceCreateResult, Absence>();
			CreateMap<Absence, AbsenceCreateResult>();
			//update
			CreateMap<AbsenceApproveArgument, Absence>();
			CreateMap<Absence, AbsenceApproveArgument>();
			CreateMap<AbsenceApproveResult, Absence>();
			CreateMap<Absence, AbsenceApproveResult>();
		}
	}
}
