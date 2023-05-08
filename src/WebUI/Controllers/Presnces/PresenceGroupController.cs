using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.PresenceGroups;
using CleanArchitecture.Application.Presences.PresenceGroups.Commands;
using CleanArchitecture.Application.Presences.PresenceGroups.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Personnels;

public class PresenceGroupController : ApiControllerBase
{
    [HttpPost("CreatePresenceGroup")]
    public async Task<ApplicationResponse<int>> CreatePresenceGroup([FromBody] CreatePresenceGroupCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetPresenceGroups")]
    public async Task<ApplicationResponse<List<BasicPresenceGroupDto>>> GetPresenceGroups([FromQuery] GetPresencesGroupsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<List<BasicPresenceGroupDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<List<BasicPresenceGroupDto>>(e);
        }
    }
    [HttpGet("GetPresenceGroupById")]
    public async Task<ApplicationResponse<PresenceGroupDto>> GetPresenceGroupById([FromQuery] GetPresenceGroupByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<PresenceGroupDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<PresenceGroupDto>(e);
        }
    }
    [HttpPost("EditPresenceGroup")]
    public async Task<ApplicationResponse<int>> EditPresenceGroup([FromBody] EditPresenceGroupCommand request, CancellationToken cancellationToken)
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
    [HttpDelete("RemovePresenceGroup")]
    public async Task<ApplicationResponse<bool>> RemovePresenceGroup([FromBody] RemovePresenceGroupCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetPresenceGroupDocuments")]
    public async Task<ApplicationResponse<List<BasicDocumentTemplateDto>>> GetPresenceGroupDocuments([FromBody] GetPresenceGroupDocumentsQuery request, CancellationToken cancellationToken)
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
    [HttpPost("AddPresenceGroupDocument")]
    public async Task<ApplicationResponse<bool>> AddPresenceGroupDocument([FromQuery] CreatePresenceGroupDocumentCommand request, CancellationToken cancellationToken)
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

    [HttpDelete("RemovePresenceGroupDocument")]
    public async Task<ApplicationResponse<bool>> RemovePresenceGroupDocument([FromBody] RemovePresenceGroupDocumentCommand request, CancellationToken cancellationToken)
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
