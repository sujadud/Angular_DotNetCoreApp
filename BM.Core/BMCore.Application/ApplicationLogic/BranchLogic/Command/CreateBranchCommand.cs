﻿

using AutoMapper;
using BMCore.Application.ApplicationLogic.BranchLogic.Model;
using BMCore.Manager.Contracts;
using BMCore.Model.Models;
using MediatR;

namespace BMCore.Application.ApplicationLogic.BranchLogic.Command
{
    public class CreateBranchCommand : BranchCreateModel, IRequest<BranchCreateModel>
    {
        public class Handler : IRequestHandler<CreateBranchCommand, BranchCreateModel>
        {
            private readonly IBranchManager _branchManager;
            private readonly IMapper _mapper;

            public Handler(IBranchManager branchManager, IMapper mapper)
            {
                _branchManager = branchManager;
                _mapper = mapper;
            }

            public async Task<BranchCreateModel> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
            {
                var createdBranch = _mapper.Map<Branch>(request);
                createdBranch.CreatedById = Guid.NewGuid().ToString();
                createdBranch.CreatedDateTime = DateTime.UtcNow;

                createdBranch = await _branchManager.CreateAsync(createdBranch);
                return request;
            }
        }
    }
}
