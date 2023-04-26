using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Presences.PresenceGroups.Queries;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Presnces;
public class PresenceController : ApiControllerBase
{
    [HttpGet("GetAreaDocuments")]
    public async Task<ApplicationResponse> GetAreaDocuments([FromBody] AreaDocumentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
    }
    [HttpGet("GetBlockDocuments")]
    public async Task<ApplicationResponse> GetBlockDocuments([FromBody] BlockDocumentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
    }
    [HttpGet("GetBrandDocuments")]
    public async Task<ApplicationResponse> GetBrandDocuments([FromBody] BrandDocumentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
    }
    [HttpGet("GetCompanyDocuments")]
    public async Task<ApplicationResponse> GetCompanyDocuments([FromBody] CompanyDocumentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
    }
    [HttpGet("GetPresenceGroupDocuments")]
    public async Task<ApplicationResponse> GetPresenceGroupDocuments([FromBody] PresenceGroupDocumentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
    }
    [HttpGet("GetSiteDocuments")]
    public async Task<ApplicationResponse> GetSiteDocuments([FromBody] SiteDocumentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
    }
    [HttpGet("GetUnitDocuments")]
    public async Task<ApplicationResponse> GetUnitDocuments([FromBody] UnitDocumentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
    }
    [HttpGet("GetZoneDocuments")]
    public async Task<ApplicationResponse> GetZoneDocuments([FromBody] ZoneDocumentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
    }
    [HttpPost("AddAreaDocuments")]
    public async Task<IActionResult> AddAreaDocuments([FromBody] AddAreaDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("AddBlockDocuments")]
    public async Task<IActionResult> AddBlockDocuments([FromBody] AddBlockDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("AddBrandDocuments")]
    public async Task<IActionResult> AddBrandDocuments([FromBody] AddBrandDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("AddCompanyDocuments")]
    public async Task<IActionResult> AddCompanyDocuments([FromBody] AddCompanyDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    } 
    [HttpPost("AddSiteDocuments")]
    public async Task<IActionResult> AddSiteDocuments([FromBody] AddSiteDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("AddUnitDocuments")]
    public async Task<IActionResult> AddUnitDocuments([FromBody] AddUnitDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("AddZoneDocuments")]
    public async Task<IActionResult> AddZoneDocuments([FromBody] AddZoneDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("RemoveAreaDocuments")]
    public async Task<IActionResult> RemoveAreaDocuments([FromBody] RemoveAreaDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("RemoveBlockDocuments")]
    public async Task<IActionResult> RemoveBlockDocuments([FromBody] RemoveBlockDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("RemoveBrandDocuments")]
    public async Task<IActionResult> RemoveBrandDocuments([FromBody] RemoveBrandDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("RemoveCompanyDocuments")]
    public async Task<IActionResult> RemoveCompanyDocuments([FromBody] RemoveCompanyDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    } 
    [HttpPost("RemoveSiteDocuments")]
    public async Task<IActionResult> RemoveSiteDocuments([FromBody] RemoveSiteDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("RemoveUnitDocuments")]
    public async Task<IActionResult> RemoveUnitDocuments([FromBody] RemoveUnitDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("RemoveZoneDocuments")]
    public async Task<IActionResult> RemoveZoneDocuments([FromBody] RemoveZoneDocuments request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
}