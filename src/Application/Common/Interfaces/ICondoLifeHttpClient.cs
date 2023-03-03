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
    public Task<bool> GetZonesAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetZoneDetailsAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetBlocksAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetBlockDetailsAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetUnitsAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetUnitDetailsAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetAreasAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetAreaDetailsAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetCompaniesAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetCompanyDetailsAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetBrandsAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetBrandDetailsAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetDepartmentsAsync(CancellationToken cancellationToken = default);
    public Task<bool> GetPersonnelDetailsAsync(CancellationToken cancellationToken = default);
}
