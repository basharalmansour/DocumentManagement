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
    [HttpPost("CreateAreaDocuments")]
    public async Task<ApplicationResponse> CreateAreaDocuments([FromBody] AddAreaDocuments request, CancellationToken cancellationToken)
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

    [HttpPost("CreateBlockDocuments")]
    public async Task<ApplicationResponse> CreateBlockDocuments([FromBody] AddBlockDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("CreateBrandDocuments")]
    public async Task<ApplicationResponse> CreateBrandDocuments([FromBody] AddBrandDocuments request, CancellationToken cancellationToken)
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

    [HttpPost("CreateCompanyDocuments")]
    public async Task<ApplicationResponse> CreateCompanyDocuments([FromBody] AddCompanyDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("CreateSiteDocuments")]
    public async Task<ApplicationResponse> CreateSiteDocuments([FromBody] AddSiteDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("CreateUnitDocuments")]
    public async Task<ApplicationResponse> CreateUnitDocuments([FromBody] AddUnitDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("CreateZoneDocuments")]
    public async Task<ApplicationResponse> CreateZoneDocuments([FromBody] AddZoneDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveAreaDocuments")]
    public async Task<ApplicationResponse> RemoveAreaDocuments([FromBody] RemoveAreaDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveBlockDocuments")]
    public async Task<ApplicationResponse> RemoveBlockDocuments([FromBody] RemoveBlockDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveBrandDocuments")]
    public async Task<ApplicationResponse> RemoveBrandDocuments([FromBody] RemoveBrandDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveCompanyDocuments")]
    public async Task<ApplicationResponse> RemoveCompanyDocuments([FromBody] RemoveCompanyDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveSiteDocuments")]
    public async Task<ApplicationResponse> RemoveSiteDocuments([FromBody] RemoveSiteDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveUnitDocuments")]
    public async Task<ApplicationResponse> RemoveUnitDocuments([FromBody] RemoveUnitDocuments request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveZoneDocuments")]
    public async Task<ApplicationResponse> RemoveZoneDocuments([FromBody] RemoveZoneDocuments request, CancellationToken cancellationToken)
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
}