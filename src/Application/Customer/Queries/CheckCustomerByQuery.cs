using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.ResponseDtos;
using CleanArchitecture.Application.Common.Extension;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using MediatR;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Application.Customer.Queries;

public class CheckCustomerByQuery : IRequest<CheckCustomerByResultDto>
{
    public string MobileNo { get; set; }
    public string Email { get; set; }
    public string IdentityNumber { get; set; }

    public class CheckCustomerByQueryHandler : IRequestHandler<CheckCustomerByQuery, CheckCustomerByResultDto>
    {
        private readonly IVeriSoftHttpClient _veriSoftHttpClient;
        public CheckCustomerByQueryHandler(IVeriSoftHttpClient veriSoftHttpClient, IOptions<AppSettings> options)
        {
            _veriSoftHttpClient = veriSoftHttpClient;
        }

        public async Task<CheckCustomerByResultDto> Handle(CheckCustomerByQuery request, CancellationToken cancellationToken)
        {
            var checkCustomerResultDto = await _veriSoftHttpClient.CheckCustomerBy(request.MobileNo, request.Email, request.IdentityNumber, cancellationToken);
            return checkCustomerResultDto;
        }
    }
}
