using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Extension;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Application.Customer.Commands;

public class SendOtpToCustomerCommand : IRequest<SendOtpMessageResult>
{
    public string Token { get; set; }
    public int CustomerId { get; set; }
    public string PhoneNumber { get; set; }
    public RequestIntegrationType IntegrationType { get; set; }

    public class SendOtsToCustomerCommandHandler : IRequestHandler<SendOtpToCustomerCommand, SendOtpMessageResult>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly string _sha1Key; 
        private readonly ICondolifeHttpClient _condolifeHttpClient;
        public SendOtsToCustomerCommandHandler(IApplicationDbContext applicationDbContext, IOptions<AppSettings> options, IOtpSmsService otpSmsService, ICondolifeHttpClient condolifeHttpClient)
        {
            _sha1Key = options.Value.Sha1Key;
            _applicationDbContext = applicationDbContext;
            _condolifeHttpClient = condolifeHttpClient;
        }

        public async Task<SendOtpMessageResult> Handle(SendOtpToCustomerCommand request, CancellationToken cancellationToken)
        {
            var decryptedToken = await request.Token.DecryptAsync(_sha1Key);
            if (decryptedToken != request.CustomerId.ToString() + " " + _sha1Key)
                throw new BadRequestException("Token not valid");

            
            var existsSms = await _applicationDbContext.Sms.FirstOrDefaultAsync(x => x.Token == request.Token && x.MessageStatus == OtpMessageStatus.Waiting);
            using (var transaction = _applicationDbContext.Database.BeginTransaction())
            {
                var otp = await _condolifeHttpClient.SendOtpMessageAsync(request.PhoneNumber, cancellationToken);
                
                try
                {
                    if (existsSms is not null)
                    {
                        existsSms.MessageStatus = OtpMessageStatus.Canceled;
                        await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    }
                    await _applicationDbContext.Sms.AddAsync(new Domain.Entities.Sms.Sms()
                    {
                        IntegrationName = Enum.GetName(request.IntegrationType.GetType(), request.IntegrationType) ?? throw new BadRequestException("Integration not found!"),
                        Duration = TimeSpan.FromSeconds(180),
                        IntegrationUserId = request.CustomerId.ToString(),
                        MessageStatus = OtpMessageStatus.Waiting,
                        Message = otp,
                        PhoneNumber = request.PhoneNumber,
                        Token = request.Token,
                        CreatedDateTime = DateTime.Now
                    });
                    await _applicationDbContext.SaveChangesAsync(cancellationToken); 
                    await transaction.CommitAsync(cancellationToken);
                    return new SendOtpMessageResult()
                    {
                         Result = true
                    };

                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
               
            }
        }
    }
}
