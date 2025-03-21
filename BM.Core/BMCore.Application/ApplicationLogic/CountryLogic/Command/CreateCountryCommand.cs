﻿using AutoMapper;
using BMCore.Application.ApplicationLogic.CountryLogic.Model;
using BMCore.Manager.Contracts;
using BMCore.Model.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BMCore.Application.ApplicationLogic.CountryLogic.Command
{
    public class CreateCountryCommand : CountryCreateModel, IRequest<CountryCreateModel>
    {
        public class Handler : IRequestHandler<CreateCountryCommand, CountryCreateModel>
        {
            private readonly ICountryManager _countryManager;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public Handler(ICountryManager countryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _countryManager = countryManager;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<CountryCreateModel> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                var createdCountry = _mapper.Map<Country>(request);
                createdCountry.CreatedById = Guid.NewGuid().ToString();
                createdCountry.CreatedDateTime = DateTime.UtcNow;

                createdCountry = await _countryManager.CreateAsync(createdCountry);
                return request;
            }
        }
    }
}