using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.DocumentsTemplate.Commands;
using CleanArchitecture.Application.DocumentsTemplate.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Documents;

public class DocumentTemplateController : ApiControllerBase
{
    [HttpPost("CreateDocumentTemplate")]
    public async Task<ApplicationResponse<int>> CreateDocumentTemplate([FromBody] CreateDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<int>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<int>(e);
        }
    }

    [HttpGet("GetDocumentTemplates")]
    public async Task<ApplicationResponse<List<BasicDocumentTemplateDto>>> GetDocumentTemplates([FromQuery] GetDocumentTemplatesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<List<BasicDocumentTemplateDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<List<BasicDocumentTemplateDto>>(e);
        }
    }

    [HttpGet("GetDocumentTemplateById")]
    public async Task<ApplicationResponse<GetDocumentTemplateDto>> GetDocumentTemplateById([FromQuery] GetDocumentTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<GetDocumentTemplateDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<GetDocumentTemplateDto>(e);
        }
    }

    [HttpGet("GetDocumentTemplateTypes")]
    public async Task<ApplicationResponse<List<KeyValuePair<int , string>>>> GetDocumentTemplateTypes([FromQuery] GetDocumentTemplateTypesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<List<KeyValuePair<int, string>>> (result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<List<KeyValuePair<int, string>>>(e);
        }
    }

    [HttpPost("EditDocumentTemplate")] 
    public async Task<ApplicationResponse<int>> EditDocumentTemplate([FromBody] EditDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<int>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<int>(e);
        }
    }

    [HttpDelete("DeleteDocumentTemplate")]
    public async Task<ApplicationResponse<bool>> DeleteDocumentTemplate([FromBody] RemoveDocumentTemplateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<bool>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<bool>(e);
        }
    }
}