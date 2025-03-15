﻿using AutoMapper;
using ExamCore.Application.ApplicationLogic.EmployeeLogic.Model;
using ExamCore.Manager.Contracts;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.EmployeeLogic.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeGridModel>>
    {
        public class Handler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeGridModel>>
        {
            private readonly IEmployeeManager _employeeManager;
            private readonly IMapper _mapper;
            public Handler(IEmployeeManager employeeManager, IMapper mapper)
            {
                _employeeManager = employeeManager;
                _mapper = mapper;
            }
            public async Task<IEnumerable<EmployeeGridModel>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {
                var getAll = await _employeeManager.GetAllAsync();
                var mapGetAll = _mapper.Map<IEnumerable<EmployeeGridModel>>(getAll);
                return mapGetAll;
            }
        }
    }
}
