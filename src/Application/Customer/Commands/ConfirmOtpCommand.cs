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
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Customer.Commands;

public class ConfirmOtpCommand : IRequest<GetIntegrationCustomerRegisterInfoDto>
{
    public string Message { get; set; }
    public string CustomerId { get; set; }
    public RequestIntegrationType Integration { get; set; }

    public class ConfirmOtpCommandHandler : IRequestHandler<ConfirmOtpCommand, GetIntegrationCustomerRegisterInfoDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IVeriSoftHttpClient _veriSoftHttpClient;
        private readonly IMapper _mapper;

        public ConfirmOtpCommandHandler(IApplicationDbContext applicationDbContext, IVeriSoftHttpClient veriSoftHttpClient, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _veriSoftHttpClient = veriSoftHttpClient;
            _mapper = mapper;
        }

        public async Task<GetIntegrationCustomerRegisterInfoDto> Handle(ConfirmOtpCommand request, CancellationToken cancellationToken)
        {
            var sms = await _applicationDbContext.Sms.FirstOrDefaultAsync(x => x.IntegrationUserId == request.CustomerId
                                                                            && x.MessageStatus == OtpMessageStatus.Waiting
                                                                            && x.Message == request.Message);
            if (sms is null)  
                throw new NotFoundException("Girdiğiniz kod hatalı. Lütfen tekrar deneyiniz!");

             
            if (!(sms.CreatedDateTime.AddSeconds(sms.Duration.TotalSeconds) >= DateTime.Now))
            {
                sms.MessageStatus = OtpMessageStatus.Overdue;
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                throw new ConflictException("Message confirmation time has expired!");
            }
                
            sms.MessageStatus = OtpMessageStatus.Confirmed;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            var verisoftCustomer = await _veriSoftHttpClient.GetCustomerInfoAsync(request.CustomerId);
            var result = _mapper.Map<GetIntegrationCustomerRegisterInfoDto>(verisoftCustomer);
            return result;
        }
    }
}
