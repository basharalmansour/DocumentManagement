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
    public Task<CreateCondoUserResultDto> CreateCustomerAsync(CreateCondoUserDto createCustomerDto, CancellationToken cancellationToken = default);
    public Task<CondoSuccessResponseDto> UpsertCustomerMembershipAsync(List<CreateCondoUserMembershipDto> createCondoUserMembershipDto, CancellationToken cancellationToken = default);
    public Task<List<CondoProgramsWithMembershipsFilterResponseDto>> FilterMembershipsAsync(CondoMemberShipFilterRequestDto condoMemberShipFilterRequestDto, CancellationToken cancellationToken = default);
    public Task<List<CondoMembershipResponseDto>> GetMembershipsAsync(CancellationToken cancellationToken = default);
    public Task<string> SendOtpMessageAsync(string phoneNumber, CancellationToken cancellationToken = default);
    public Task<List<GetCondoCities>> GetCitiesAsync(int countryId, CancellationToken cancellationToken = default);
    public Task<List<GetCondoDistricts>> GetDistrictsAsync(int cityId, CancellationToken cancellationToken = default);
    public Task<List<GetCondoCountries>> GetCountriesAsync(CancellationToken cancellationToken = default);
    public Task<CondoUserInfoDto> GetUserInfoAsync(string userId, CancellationToken cancellationToken = default);
    public Task<CondoMembershipResponseDto> GetMembership(int memebershipId, CancellationToken cancellationToken = default);
    public Task<List<CondoMembershipResponseDto>> GetUserMembership(Guid userId, CancellationToken cancellationToken = default);
    public Task<string> GetIntegrationMembershipId(string membershipId, CancellationToken cancellationToken = default);
    public Task<CondoUserInfoDto> GetUserInfoByIntegrationId(string integrationUserId, CancellationToken cancellationToken = default);
    public Task<bool> UpdateUserInfo(CreateCondoUserDto userDto,Guid userId,CancellationToken cancellationToken = default);
    public Task<int> GetUserMembershipIdByUserId(Guid userId, CancellationToken cancellationToken = default);
    public Task<CondoUserInfoDto> GetUserInfoByPhoneNumberAndEmail(string phoneNumber, string email, CancellationToken cancellationToken = default);
    public Task<bool> PublishMessage(NotificationRequestDto requestDto, CancellationToken cancellationToken = default);
    public Task<List<CondoAdvantageDto>> GetIntegrationAdvantagesAsync(int membershipId, CancellationToken cancellationToken = default);
    public Task<CondoSuccessResponseDto> UpsertIntegrationAdvantage(CondoAdvantageDto condoAdvantageDto, CancellationToken cancellationToken = default);
    public Task<CondoSuccessResponseDto> DeleteAdvantage(int advantageId, CancellationToken cancellationToken = default);
}
