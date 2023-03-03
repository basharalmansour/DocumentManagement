using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.Appllication;
using CleanArchitecture.Application.Common.Dtos.CondoLife;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICondolifeHttpClient
{
    public Task<string> SendOtpMessageAsync(string phoneNumber, CancellationToken cancellationToken = default);
    public Task<CondoUserInfoDto> GetUserInfoAsync(string userId, CancellationToken cancellationToken = default);
    public Task<CondoUserInfoDto> GetUserInfoByPhoneNumberAndEmail(string phoneNumber, string email, CancellationToken cancellationToken = default);
    public Task<bool> PublishMessage(NotificationRequestDto requestDto, CancellationToken cancellationToken = default);
}
