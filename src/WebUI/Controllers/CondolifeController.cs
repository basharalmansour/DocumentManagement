using CleanArchitecture.Application.Common.Dtos.CondoLife.RequestDtos;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.DocumentsTemplate.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
public class CondolifeController : ApiControllerBase
{
    private readonly ICondolifeHttpClient _condolifeHttpClient;

    public CondolifeController(ICondolifeHttpClient condolifeHttpClient)
    {
        _condolifeHttpClient = condolifeHttpClient;
    }

    [HttpPost("GetSitesAsync")]
    public async Task<IActionResult> GetSitesAsync([FromBody] GetSitesRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetSitesAsync(request);
        return Ok(result);
    }

    [HttpPost("GetSiteDetailsAsync")]
    public async Task<IActionResult> GetSiteDetailsAsync([FromBody] Guid siteId, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetSiteDetailsAsync(siteId);
        return Ok(result);
    }

    [HttpPost("GetZonesAsync")]
    public async Task<IActionResult> GetZonesAsync([FromBody] GetZonesRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetZonesAsync(request);
        return Ok(result);
    }

    [HttpPost("GetZoneDetailsAsync")]
    public async Task<IActionResult> GetZoneDetailsAsync([FromBody] Guid zoneId, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetZoneDetailsAsync(zoneId);
        return Ok(result);
    }

    [HttpPost("GetBlocksAsync")]
    public async Task<IActionResult> GetBlocksAsync([FromBody] string searchText, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetBlocksAsync(searchText);
        return Ok(result);
    }

    [HttpPost("GetBlockDetailsAsync")]
    public async Task<IActionResult> GetBlockDetailsAsync([FromBody] Guid blockId, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetBlockDetailsAsync(blockId);
        return Ok(result);
    }

    [HttpPost("GetUnitsAsync")]
    public async Task<IActionResult> GetUnitsAsync([FromBody] GetUnitsRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetUnitsAsync(request);
        return Ok(result);
    }

    [HttpPost("GetUnitDetailsAsync")]
    public async Task<IActionResult> GetUnitDetailsAsync([FromBody] int unitId, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetUnitDetailsAsync(unitId);
        return Ok(result);
    }

    [HttpPost("GetAreasAsync")]
    public async Task<IActionResult> GetAreasAsync([FromBody] GetAreasRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetAreasAsync(request);
        return Ok(result);
    }

    [HttpPost("GetAreaDetailsAsync")]
    public async Task<IActionResult> GetAreaDetailsAsync([FromBody] int areaId, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetAreaDetailsAsync(areaId);
        return Ok(result);
    }

    [HttpPost("GetCompaniesAsync")]
    public async Task<IActionResult> GetCompaniesAsync([FromBody] GetCompaniesRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetCompaniesAsync(request);
        return Ok(result);
    }

    [HttpPost("GetCompanyDetailsAsync")]
    public async Task<IActionResult> GetCompanyDetailsAsync([FromBody] int companyId, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetCompanyDetailsAsync(companyId);
        return Ok(result);
    }

    [HttpPost("GetBrandsAsync")]
    public async Task<IActionResult> GetBrandsAsync([FromBody] GetBrandsRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetBrandsAsync(request);
        return Ok(result);
    }

    [HttpPost("GetBrandDetailsAsync")]
    public async Task<IActionResult> GetBrandDetailsAsync([FromBody] int brandId, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetBrandDetailsAsync(brandId);
        return Ok(result);
    }

    [HttpPost("GetDepartmentsAsync")]
    public async Task<IActionResult> GetDepartmentsAsync([FromBody] GetDepartmentsRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetDepartmentsAsync(request);
        return Ok(result);
    }

    [HttpPost("GetPersonnelsAsync")]
    public async Task<IActionResult> GetPersonnelsAsync([FromBody] GetPersonnelsRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetPersonnelsAsync(request);
        return Ok(result);
    }

    [HttpPost("GetPersonnelDetailsAsync")]
    public async Task<IActionResult> GetPersonnelDetailsAsync([FromBody] int personnelId, CancellationToken cancellationToken)
    {
        var result = await _condolifeHttpClient.GetPersonnelDetailsAsync(personnelId);
        return Ok(result);
    }
}
