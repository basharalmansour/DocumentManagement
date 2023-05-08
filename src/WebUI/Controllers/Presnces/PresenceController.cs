using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Presences.PresenceGroups.Queries;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Personnels;
public class PresenceController : ApiControllerBase
{
    [HttpGet("GetAreaDocuments")]
    public async Task<ApplicationResponse<List<BasicDocumentTemplateDto>>> GetAreaDocuments([FromBody] GetAreaDocumentsQuery request, CancellationToken cancellationToken)
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
    [HttpGet("GetBlockDocuments")]
    public async Task<ApplicationResponse<List<BasicDocumentTemplateDto>>> GetBlockDocuments([FromBody] GetBlockDocumentsQuery request, CancellationToken cancellationToken)
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
    [HttpGet("GetBrandDocuments")]
    public async Task<ApplicationResponse<List<BasicDocumentTemplateDto>>> GetBrandDocuments([FromBody] GetBrandDocumentsQuery request, CancellationToken cancellationToken)
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
    [HttpGet("GetCompanyDocuments")]
    public async Task<ApplicationResponse<List<BasicDocumentTemplateDto>>> GetCompanyDocuments([FromBody] GetCompanyDocumentsQuery request, CancellationToken cancellationToken)
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
    [HttpGet("GetSiteDocuments")]
    public async Task<ApplicationResponse<List<BasicDocumentTemplateDto>>> GetSiteDocuments([FromBody] GetSiteDocumentsQuery request, CancellationToken cancellationToken)
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
    [HttpGet("GetUnitDocuments")]
    public async Task<ApplicationResponse<List<BasicDocumentTemplateDto>>> GetUnitDocuments([FromBody] GetUnitDocumentsQuery request, CancellationToken cancellationToken)
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
    [HttpGet("GetZoneDocuments")]
    public async Task<ApplicationResponse<List<BasicDocumentTemplateDto>>> GetZoneDocuments([FromBody] GetZoneDocumentsQuery request, CancellationToken cancellationToken)
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
    [HttpPost("CreateAreaDocuments")]
    public async Task<ApplicationResponse<bool>> CreateAreaDocuments([FromBody] CreateAreaDocumentsCommand request, CancellationToken cancellationToken)
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

    [HttpPost("CreateBlockDocuments")]
    public async Task<ApplicationResponse<bool>> CreateBlockDocuments([FromBody] CreateBlockDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("CreateBrandDocuments")]
    public async Task<ApplicationResponse<bool>> CreateBrandDocuments([FromBody] CreateBrandDocumentsCommand request, CancellationToken cancellationToken)
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

    [HttpPost("CreateCompanyDocuments")]
    public async Task<ApplicationResponse<bool>> CreateCompanyDocuments([FromBody] CreateCompanyDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("CreateSiteDocuments")]
    public async Task<ApplicationResponse<bool>> CreateSiteDocuments([FromBody] CreateSiteDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("CreateUnitDocuments")]
    public async Task<ApplicationResponse<bool>> CreateUnitDocuments([FromBody] CreateUnitDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("CreateZoneDocuments")]
    public async Task<ApplicationResponse<bool>> CreateZoneDocuments([FromBody] CreateZoneDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveAreaDocuments")]
    public async Task<ApplicationResponse<bool>> RemoveAreaDocuments([FromBody] RemoveAreaDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveBlockDocuments")]
    public async Task<ApplicationResponse<bool>> RemoveBlockDocuments([FromBody] RemoveBlockDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveBrandDocuments")]
    public async Task<ApplicationResponse<bool>> RemoveBrandDocuments([FromBody] RemoveBrandDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveCompanyDocuments")]
    public async Task<ApplicationResponse<bool>> RemoveCompanyDocuments([FromBody] RemoveCompanyDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveSiteDocuments")]
    public async Task<ApplicationResponse<bool>> RemoveSiteDocuments([FromBody] RemoveSiteDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveUnitDocuments")]
    public async Task<ApplicationResponse<bool>> RemoveUnitDocuments([FromBody] RemoveUnitDocumentsCommand request, CancellationToken cancellationToken)
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
    [HttpPost("RemoveZoneDocuments")]
    public async Task<ApplicationResponse<bool>> RemoveZoneDocuments([FromBody] RemoveZoneDocumentsCommand request, CancellationToken cancellationToken)
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