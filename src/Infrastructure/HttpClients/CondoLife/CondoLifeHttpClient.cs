using CleanArchitecture.Application.Common.Dtos.CondoLife;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Application.Common.Dtos.CondoLife.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;

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
    
    //public async Task<CreateCondoUserResultDto> CreateCustomerAsync(CreateCondoUserDto createCustomerDto, CancellationToken cancellationToken = default)
    //{
    //    var result = await PostAsync<CreateCondoUserResultDto>(_settings.CreateUser, createCustomerDto, cancellationToken: cancellationToken);
    //    return result;
    //}

    //public async Task<CondoSuccessResponseDto> UpsertCustomerMembershipAsync(List<CreateCondoUserMembershipDto> createCondoUserMembershipDto, CancellationToken cancellationToken = default)
    //{
    //    var content = PrepareJsonBodyContent(createCondoUserMembershipDto);
    //    var requestMessage = new HttpRequestMessage(HttpMethod.Post, _settings.CreateCondoUserMembership) { Content = content };

    //    var responseMessage = await _httpClient.SendAsync(requestMessage, cancellationToken);
    //    var contentresp = await responseMessage.Content.ReadAsStringAsync();
    //    var result = System.Text.Json.JsonSerializer.Deserialize<CondoSuccessResponseDto>(contentresp);
    //    return result;
    //}

    //public async Task<string> GetIntegrationMembershipId(string membershipId, CancellationToken cancellationToken = default)
    //{
    //    var url = _settings.GetIntegrationMembershipId.Replace("{membershipId}", membershipId);
    //    var result = await GetAsync<string>(url, cancellationToken);
    //    return result;
    //}
    //public async Task<List<GetCondoCountries>> GetCountriesAsync(CancellationToken cancellationToken = default)
    //{
    //    var result = await GetAsync<List<GetCondoCountries>>(_settings.GetCountries, cancellationToken);
    //    return result;
    //}

    
    public async Task<CondoUserInfoDto> GetUserInfoAsync(string userId, CancellationToken cancellationToken = default)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, _settings.GetUserInfo.Replace("{userId}", userId)) { };
        var responseMessage = await _httpClient.SendAsync(requestMessage, cancellationToken);
        var contentresp = await responseMessage.Content.ReadAsStringAsync();
        var result = System.Text.Json.JsonSerializer.Deserialize<CondoUserInfoDto>(contentresp);
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

    public async Task<List<GetSitesResponseDto>> GetSitesAsync(GetSitesRequestDto request, CancellationToken cancellationToken = default) 
    {
        var url = _settings.GetSites;
        var result = await PostAsync<List<GetSitesResponseDto>>(url, request, cancellationToken);
        return result;
    }

    public async Task<GetSiteDetailsResponseDto> GetSiteDetailsAsync(Guid siteId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetSiteDetails;
        var result = await PostAsync<GetSiteDetailsResponseDto>(url, siteId, cancellationToken);
        return result;
    }
    public async Task<List<GetZonesResponseDto>> GetZonesAsync(GetZonesRequestDto request, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetZones;
        var result = await PostAsync<List<GetZonesResponseDto>>(url, request, cancellationToken);
        return result;
    }
    public async Task<GetZonesResponseDto> GetZoneDetailsAsync(Guid zoneId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetZoneDetails;
        var result = await PostAsync<GetZonesResponseDto>(url, zoneId, cancellationToken);
        return result;
    }
    public async Task<List<GetBlocksResponseDto>> GetBlocksAsync(string searchText, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetBlocks;
        var result = await PostAsync<List<GetBlocksResponseDto>>(url, searchText, cancellationToken);
        return result;
    }
    public async Task<GetBlockDetailsResponse> GetBlockDetailsAsync(Guid blockId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetBlockDetails;
        var result = await PostAsync<GetBlockDetailsResponse>(url, blockId, cancellationToken);
        return result;
    }
    public async Task<List<GetUnitsResponseDto>> GetUnitsAsync(GetUnitsRequestDto request, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetUnits;
        var result = await PostAsync<List<GetUnitsResponseDto>>(url, request, cancellationToken);
        return result;
    }
    public async Task<GetUnitDetailsResponseDto> GetUnitDetailsAsync(int unitId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetUnitDetails;
        var result = await PostAsync<GetUnitDetailsResponseDto>(url, unitId, cancellationToken);
        return result;
    }
    public async Task<List<GetAreasResponseDto>> GetAreasAsync(GetAreasRequestDto request, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetAreas;
        var result = await PostAsync<List<GetAreasResponseDto>>(url, request, cancellationToken);
        return result;
    }
    public async Task<GetAreaDetailsResponseDto> GetAreaDetailsAsync(int areaId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetAreaDetails;
        var result = await PostAsync<GetAreaDetailsResponseDto>(url, areaId, cancellationToken);
        return result;
    }
    public async Task<List<GetCompaniesResponseDto>> GetCompaniesAsync(GetCompaniesRequestDto request, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetCompanies;
        var result = await PostAsync<List<GetCompaniesResponseDto>>(url, request, cancellationToken);
        return result;
    }
    public async Task<GetCompanyDetailsResponseDto> GetCompanyDetailsAsync(int companyId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetCompanyDetails;
        var result = await PostAsync<GetCompanyDetailsResponseDto>(url, companyId, cancellationToken);
        return result;
    }
    public async Task<List<GetBrandsResponseDto>> GetBrandsAsync(GetBrandsRequestDto request, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetBrands;
        var result = await PostAsync<List<GetBrandsResponseDto>>(url, request, cancellationToken);
        return result;
    }
    public async Task<GetBrandDetailsResponseDto> GetBrandDetailsAsync(int brandId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetBrandDetails;
        var result = await PostAsync<GetBrandDetailsResponseDto>(url, brandId, cancellationToken);
        return result;
    }
    public async Task<List<GetDepartmentsResponseDto>> GetDepartmentsAsync(GetDepartmentsRequestDto request, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetDepartments;
        var result = await PostAsync<List<GetDepartmentsResponseDto>>(url, request, cancellationToken);
        return result;
    }
    public async Task<List<GetPersonnelsResponseDto>> GetPersonnelsAsync(GetPersonnelsRequestDto request, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetPersonnels;
        var result = await PostAsync<List<GetPersonnelsResponseDto>>(url, request, cancellationToken);
        return result;
    }
    public async Task<GetPersonnelDetailsResponseDto> GetPersonnelDetailsAsync(int personnelId, CancellationToken cancellationToken = default)
    {
        var url = _settings.GetPersonnelDetails;
        var result = await PostAsync<GetPersonnelDetailsResponseDto>(url, personnelId, cancellationToken);
        return result;
    }
}
