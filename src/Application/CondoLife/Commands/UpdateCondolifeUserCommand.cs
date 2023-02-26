using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.RequestDtos;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.CondoLife.Commands;

public class UpdateCondolifeUserCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
    public string IntegrationUserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime? BirthDate { get; set; }
    public string GenderName { get; set; }
    public string CitizenNumber { get; set; }
    public bool MaritialStatus { get; set; }
    public DateTime MaritialDate { get; set; }
    public int? CountryId { get; set; }
}

public class UpdateCondolifeUserCommandHandler : IRequestHandler<UpdateCondolifeUserCommand, bool>
{
    private readonly IVeriSoftHttpClient _veriSoftHttpClient;
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateCondolifeUserCommandHandler(IVeriSoftHttpClient veriSoftHttpClient, IMapper mapper, IApplicationDbContext applicationDbContext)
    {
        _veriSoftHttpClient = veriSoftHttpClient;
        _mapper = mapper;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateCondolifeUserCommand request, CancellationToken cancellationToken)
    {
        var verisoftUser = await _veriSoftHttpClient.GetCustomerInfoAsync(request.IntegrationUserId, cancellationToken);
        var integrationCountry = _applicationDbContext.IntegrationCountries.FirstOrDefault(x => x.CondoLifeCountryId == request.CountryId);
       
        var updateCustomerInfoRequestDto = _mapper.Map<UpdateCustomerInfoRequestDto>(verisoftUser);
        _mapper.Map<UpdateCondolifeUserCommand, UpdateCustomerInfoRequestDto>(request, updateCustomerInfoRequestDto);
 
        await _veriSoftHttpClient.UpdateCustomerInfoAsync(updateCustomerInfoRequestDto);
        return true;
    }
}
