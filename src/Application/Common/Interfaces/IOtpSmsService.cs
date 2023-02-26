using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
 

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IOtpSmsService
{
    /// <summary>
    /// Generate an OTP message and send to mobile phone
    /// </summary>
    /// <param name="otpSetting"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<string> SendSmsAsync(string phoneNumber, CancellationToken cancellationToken = default); 
}
