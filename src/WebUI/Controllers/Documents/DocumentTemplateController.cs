using CleanArchitecture.Application.DocumentsTemplate.Commands;
using CleanArchitecture.Application.DocumentsTemplate.Queries;
using CleanArchitecture.Application.DocumentsTemplate.Queries.Presences;
using CleanArchitecture.Application.ServiceCategories.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Documents;

public class DocumentTemplateController : ApiControllerBase
{
    [HttpPost("AddDocumentTemplate")]
    public async Task<IActionResult> CreateDocumentTemplate([FromBody] CreateDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetDocumentTemplates")]
    public async Task<IActionResult> GetDocumentTemplates([FromQuery] GetDocumentTemplatesQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetDocumentTemplateById")]
    public async Task<IActionResult> GetDocumentTemplateById([FromQuery] GetDocumentTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost("EditDocumentTemplate")] 
    public async Task<IActionResult> EditDocumentTemplate([FromBody] EditDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("DeleteDocumentTemplate")]
    public async Task<IActionResult> DeleteDocumentTemplate([FromBody] RemoveDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
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
}