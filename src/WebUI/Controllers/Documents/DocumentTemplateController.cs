using CleanArchitecture.Application.DocumentsTemplate.Commands;
using CleanArchitecture.Application.DocumentsTemplate.Queries;
using CleanArchitecture.Application.Presences.PresenceGroups.Queries;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using CleanArchitecture.Application.ServiceCategories.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Documents;

public class DocumentTemplateController : ApiControllerBase
{
    [HttpPost("CreateDocumentTemplate")]
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

    [HttpGet("GetDocumentTemplateTypes")]
    public async Task<IActionResult> GetDocumentTemplateTypes([FromQuery] GetDocumentTemplateTypesQuery request, CancellationToken cancellationToken)
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
}