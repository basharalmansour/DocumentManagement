using CleanArchitecture.Application.Presences.PresenceGroups.Queries;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Presnces;
public class PresenceController : ApiControllerBase
{
    [HttpGet("GetAreaDocuments")]
    public async Task<IActionResult> GetAreaDocuments([FromBody] AreaDocumentsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetBlockDocuments")]
    public async Task<IActionResult> GetBlockDocuments([FromBody] BlockDocumentsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetBrandDocuments")]
    public async Task<IActionResult> GetBrandDocuments([FromBody] BrandDocumentsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetCompanyDocuments")]
    public async Task<IActionResult> GetCompanyDocuments([FromBody] CompanyDocumentsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetPresenceGroupDocuments")]
    public async Task<IActionResult> GetPresenceGroupDocuments([FromBody] PresenceGroupDocumentsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetSiteDocuments")]
    public async Task<IActionResult> GetSiteDocuments([FromBody] SiteDocumentsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetUnitDocuments")]
    public async Task<IActionResult> GetUnitDocuments([FromBody] UnitDocumentsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetZoneDocuments")]
    public async Task<IActionResult> GetZoneDocuments([FromBody] ZoneDocumentsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
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
}
