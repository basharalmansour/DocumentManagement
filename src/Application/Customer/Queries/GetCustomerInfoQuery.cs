using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Enums.VeriSoftEnums;
using MediatR;

namespace CleanArchitecture.Application.Customer.Queries;

public class GetCustomerInfoQuery : IRequest<GetIntegrationCustomerRegisterInfoDto>
{
    public string CustomerId { get; set; }
    public RequestIntegrationType Integration { get; set; }

    public class GetCustomerInfoQueryHandler : IRequestHandler<GetCustomerInfoQuery, GetIntegrationCustomerRegisterInfoDto>
    {
        private readonly IVeriSoftHttpClient _veriSoftHttpClient;
        private readonly IMapper _mapper;

        public GetCustomerInfoQueryHandler(IVeriSoftHttpClient veriSoftHttpClient, IMapper mapper)
        {
            _veriSoftHttpClient = veriSoftHttpClient;
            _mapper = mapper;
        }

        public async Task<GetIntegrationCustomerRegisterInfoDto> Handle(GetCustomerInfoQuery request, CancellationToken cancellationToken)
        {
            switch (request.Integration)
            {
                case RequestIntegrationType.TAV:
                            var customerInfo = await _veriSoftHttpClient.GetCustomerInfoAsync(request.CustomerId, cancellationToken);
                            var responseData = _mapper.Map<GetIntegrationCustomerRegisterInfoDto>(customerInfo);
                            return responseData;
                    break;
                default:
                    throw new NotFoundException("Integration not found");
            }

        }
    }
}
