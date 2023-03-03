using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.Appllication;
using CleanArchitecture.Application.Common.Dtos.CondoLife;
using CleanArchitecture.Application.Common.Dtos.CondoLife.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICondolifeHttpClient
{
    public Task<string> SendOtpMessageAsync(string phoneNumber, CancellationToken cancellationToken = default);
    public Task<CondoUserInfoDto> GetUserInfoAsync(string userId, CancellationToken cancellationToken = default);
    public Task<CondoUserInfoDto> GetUserInfoByPhoneNumberAndEmail(string phoneNumber, string email, CancellationToken cancellationToken = default);
    public Task<bool> PublishMessage(NotificationRequestDto requestDto, CancellationToken cancellationToken = default);
    public Task<List<GetSitesResponseDto>> GetSitesAsync(GetSitesRequestDto request,CancellationToken cancellationToken = default);
    public Task<GetSiteDetailsResponseDto> GetSiteDetailsAsync(Guid siteId, CancellationToken cancellationToken = default);
    public Task<List<GetZonesResponseDto>> GetZonesAsync(GetZonesRequestDto request, CancellationToken cancellationToken = default);
    public Task<GetZonesResponseDto> GetZoneDetailsAsync(Guid zoneId, CancellationToken cancellationToken = default);
    public Task<List<GetBlocksResponseDto>> GetBlocksAsync(string searchText, CancellationToken cancellationToken = default);
    public Task<GetBlockDetailsResponse> GetBlockDetailsAsync(Guid blockId, CancellationToken cancellationToken = default);
    public Task<List<GetUnitsResponseDto>> GetUnitsAsync(GetUnitsRequestDto request, CancellationToken cancellationToken = default);
    public Task<GetUnitDetailsResponseDto> GetUnitDetailsAsync(int unitId, CancellationToken cancellationToken = default);
    public Task<List<GetAreasResponseDto>> GetAreasAsync(GetAreasRequestDto request, CancellationToken cancellationToken = default);
    public Task<GetAreaDetailsResponseDto> GetAreaDetailsAsync(int areaId, CancellationToken cancellationToken = default);
    public Task<List<GetCompaniesResponseDto>> GetCompaniesAsync(GetCompaniesRequestDto request, CancellationToken cancellationToken = default);
    public Task<GetCompanyDetailsResponseDto> GetCompanyDetailsAsync(int companyId, CancellationToken cancellationToken = default);
    public Task<List<GetBrandsResponseDto>> GetBrandsAsync(GetBrandsRequestDto request, CancellationToken cancellationToken = default);
    public Task<GetBrandDetailsResponseDto> GetBrandDetailsAsync(int brandId, CancellationToken cancellationToken = default);
    public Task<List<GetDepartmentsResponseDto>> GetDepartmentsAsync(GetDepartmentsRequestDto request, CancellationToken cancellationToken = default);
    public Task<List<GetPersonnelsResponseDto>> GetPersonnelsAsync(GetPersonnelsRequestDto request, CancellationToken cancellationToken = default);
    public Task<GetPersonnelDetailsResponseDto> GetPersonnelDetailsAsync(int personnelId, CancellationToken cancellationToken = default);
}
