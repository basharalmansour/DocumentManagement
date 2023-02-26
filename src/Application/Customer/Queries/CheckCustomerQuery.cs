using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.ResponseDtos;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Extension;
using CleanArchitecture.Application.Common.Interfaces; 
using CleanArchitecture.Domain.Common; 
using CleanArchitecture.Domain.Enums; 
using MediatR;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Application.Customer.Queries;

public class CheckCustomerQuery : IRequest<CheckCustomerResultDto>
{
    public string CardNo { get; set; }
    public string MobileNo { get; set; }
    public RequestIntegrationType Integration { get; set; }
    public class CheckCustomerQueryHandler : IRequestHandler<CheckCustomerQuery, CheckCustomerResultDto>
    {
        private readonly IVeriSoftHttpClient _veriSoftHttpClient;
        private readonly IApplicationDbContext _context;
        private readonly IOtpSmsService _otpSmsService;
        private readonly string _sha1Key;
        public CheckCustomerQueryHandler(IVeriSoftHttpClient veriSoftHttpClient, IApplicationDbContext context, IOtpSmsService otpSmsService,IOptions<AppSettings> options)
        {
            _veriSoftHttpClient = veriSoftHttpClient;
            _context = context;
            _otpSmsService = otpSmsService;
            _sha1Key = options.Value.Sha1Key;
        }

        public async Task<CheckCustomerResultDto> Handle(CheckCustomerQuery request, CancellationToken cancellationToken)
        {
            switch (request.Integration)
            {
                case RequestIntegrationType.TAV:
                    var checkCustomerResultDto = await _veriSoftHttpClient.CheckCustomerAsync(request.CardNo, request.MobileNo, cancellationToken);
                    checkCustomerResultDto.Token = await (checkCustomerResultDto.Customer_ID.ToString()+" "+_sha1Key).EncryptAsync(_sha1Key,cancellationToken);
                    return checkCustomerResultDto;
                default:
                    throw new NotFoundException("Integration not found! parameter : "+ nameof(request.Integration));
            }
        }
    }
}
