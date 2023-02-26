using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure.Services;

public class OtpSmsService : IOtpSmsService
{
    private readonly OtpSettings _otpSettings;
    public OtpSmsService(IOptions<AppSettings> options)
    {
        _otpSettings = options.Value.OtpSettings;
    }
    public Task<string> SendSmsAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
