using CleanArchitecture.Application.Common.Dtos.CondoLife;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Infrastructure.HttpClients.CondoLife;

public class CondoLifeHttpClient : BaseHttpClient, ICondolifeHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly CondoLifeClientSettings _settings;
    private readonly ICurrentUserService _currentUserService;

    public CondoLifeHttpClient(HttpClient httpClient, IOptions<AppSettings> options, ICurrentUserService currentUserService) : base(httpClient)
    {
        _settings = options.Value.ClientSettings.CondoLife;
        _httpClient = httpClient;
        _currentUserService = currentUserService;
    }
    public async Task<List<CondoMembershipResponseDto>> GetMembershipsAsync(CancellationToken cancellationToken = default)
    {
        var result = await PostAsync<List<CondoMembershipResponseDto>>(_settings.MembershipsByIntegrationCode,
            new { Code = _settings.TavCode }, cancellationToken);
        return result;
    }


    public async Task<CreateCondoUserResultDto> CreateCustomerAsync(CreateCondoUserDto createCustomerDto, CancellationToken cancellationToken = default)
    {
        var result = await PostAsync<CreateCondoUserResultDto>(_settings.CreateUser, createCustomerDto, cancellationToken: cancellationToken);
        return result;
    }

    public async Task<CondoSuccessResponseDto> UpsertCustomerMembershipAsync(List<CreateCondoUserMembershipDto> createCondoUserMembershipDto, CancellationToken cancellationToken = default)
    {
        var content = PrepareJsonBodyContent(createCondoUserMembershipDto);
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, _settings.CreateCondoUserMembership) { Content = content };

        var responseMessage = await _httpClient.SendAsync(requestMessage, cancellationToken);
        var contentresp = await responseMessage.Content.ReadAsStringAsync();
        var result = System.Text.Json.JsonSerializer.Deserialize<CondoSuccessResponseDto>(contentresp);
        return result;
    }

    public async Task<List<CondoProgramsWithMembershipsFilterResponseDto>> FilterMembershipsAsync(CondoMemberShipFilterRequestDto condoMemberShipFilterRequestDto, CancellationToken cancellationToken = default)
    {
        var result = await PostAsync<List<CondoProgramsWithMembershipsFilterResponseDto>>(_settings.FilterProgram, condoMemberShipFilterRequestDto, cancellationToken: cancellationToken);
        return result;
    }
    public async Task<string> GetIntegrationMembershipId(string membershipId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetIntegrationMembershipId.Replace("{membershipId}", membershipId);
        var result = await GetAsync<string>(url, cancellationToken);
        return result;
    }
    public async Task<CondoMembershipResponseDto> GetMembership(int memebershipId, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<CondoMembershipResponseDto>(_settings.FindMembership.Replace("{membershipId}", memebershipId.ToString()));
        return result;
    }

    public async Task<List<GetCondoCities>> GetCitiesAsync(int countryId, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<List<GetCondoCities>>(_settings.GetCities.Replace("{countryId}", countryId.ToString()), cancellationToken);
        return result;
    }

    public async Task<List<GetCondoCountries>> GetCountriesAsync(CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<List<GetCondoCountries>>(_settings.GetCountries, cancellationToken);
        return result;
    }

    public async Task<List<GetCondoDistricts>> GetDistrictsAsync(int cityId, CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<List<GetCondoDistricts>>(_settings.GetDistricts.Replace("{cityId}", cityId.ToString()), cancellationToken);
        return result;
    }

    public async Task<CondoUserInfoDto> GetUserInfoAsync(string userId, CancellationToken cancellationToken = default)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, _settings.GetUserInfo.Replace("{userId}", userId)) { };
        var responseMessage = await _httpClient.SendAsync(requestMessage, cancellationToken);
        var contentresp = await responseMessage.Content.ReadAsStringAsync();
        var result = System.Text.Json.JsonSerializer.Deserialize<CondoUserInfoDto>(contentresp);
        return result;
    }
    public Task<CondoUserInfoDto> GetUserInfoByIntegrationId(string integrationUserId, CancellationToken cancellationToken = default)
    {
        var result = GetAsync<CondoUserInfoDto>(_settings.GetUserInfoByIntegrationUserId.Replace("{userId}", integrationUserId), cancellationToken);
        return result;
    }
    public async Task<string> SendOtpMessageAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        string sOTP = String.Empty;
        string sTempChars = String.Empty;
        Random rand = new Random();
        string[] saAllowedCharacters = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        for (int i = 0; i < 6; i++)
        {
            sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
            sOTP += sTempChars;
        }
        var createOtpDto = new CreateCondoOtpMessageDto()
        {
            Message = sOTP,
            Phone = phoneNumber,
            SiteId = _currentUserService.SiteId
        };
        await PostAsync<CondoSuccessResponseDto>(_settings.SendOtpMessage, createOtpDto, cancellationToken: cancellationToken);
        return sOTP;
    }

    public async Task<bool> UpdateUserInfo(CreateCondoUserDto userDto, Guid userId, CancellationToken cancellationToken = default)
    {
        var url = _settings.UpdateUser.Replace("{userId}", userId.ToString());
        var result = await PostAsync<bool>(url, userDto, cancellationToken);
        return result;
    }

    public async Task<List<CondoMembershipResponseDto>> GetUserMembership(Guid userId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetUserMembership.Replace("{userId}", userId.ToString());
        var result = await GetAsync<List<CondoMembershipResponseDto>>(url, cancellationToken);
        return result;
    }

    public async Task<int> GetUserMembershipIdByUserId(Guid userId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetUserMembershipIdByUserId.Replace("{userId}", userId.ToString());
        var result = await GetAsync<int>(url, cancellationToken);
        return result;
    }

    public async Task<CondoUserInfoDto> GetUserInfoByPhoneNumberAndEmail(string phoneNumber, string email, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetUserByPhoneNumberAndEmail.Replace("{phoneNumber}", phoneNumber)
                                                        .Replace("{email}", email);
        var result = await GetAsync<CondoUserInfoDto>(url, cancellationToken);
        return result;
    }

    public async Task<bool> PublishMessage(NotificationRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        var url = _settings.PublishMessage;

        var result = await PostAsync<bool>(url, requestDto, cancellationToken);

        return result;
    }

    public async Task<List<CondoAdvantageDto>> GetIntegrationAdvantagesAsync(int membershipId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetIntegrationAdvantages.Replace("{memberShipId}", membershipId.ToString());
        var result = await GetAsync<List<CondoAdvantageDto>>(url, cancellationToken);
        return result;
    }

    public async Task<CondoSuccessResponseDto> UpsertIntegrationAdvantage(CondoAdvantageDto condoAdvantageDto, CancellationToken cancellationToken = default)
    {
        var url = _settings.UpsertIntegrationAdvantage;
        var result = await PostAsync<CondoSuccessResponseDto>(url, condoAdvantageDto, cancellationToken);
        return result;
    }

    public async Task<CondoSuccessResponseDto> DeleteAdvantage(int membershipId, CancellationToken cancellationToken = default)
    {
        var url = _settings.DeleteAdvantage.Replace("{advantageId}", membershipId.ToString());
        var result = await PostAsync<CondoSuccessResponseDto>(url,null, cancellationToken);
        return result;
    }
}
