using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Customer.Queries;

public class GetCustomerAdvantagesQuery : IRequest<List<GetCustomerAdvantagesDto>>
{
    public string IntegrationUserId { get; set; }

}


public class GetCustomerAdvantagesQueryHandler : IRequestHandler<GetCustomerAdvantagesQuery, List<GetCustomerAdvantagesDto>>
{
    private readonly IVeriSoftHttpClient _verisoftHttpClient;
    private readonly IMapper _mapper;
    public GetCustomerAdvantagesQueryHandler(IVeriSoftHttpClient verisoftHttpClient, IMapper mapper)
    {
        _verisoftHttpClient = verisoftHttpClient;
        _mapper = mapper;
    }

    public async Task<List<GetCustomerAdvantagesDto>> Handle(GetCustomerAdvantagesQuery request, CancellationToken cancellationToken)
    {
        var verisoftResult = await _verisoftHttpClient.GetCustomerCreditsAsync(request.IntegrationUserId, cancellationToken);
        var result = _mapper.Map<List<GetCustomerAdvantagesDto>>(verisoftResult);
        return result;
    }
}