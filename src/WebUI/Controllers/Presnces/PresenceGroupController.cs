using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Presences.PresenceGroups.Commands;
using CleanArchitecture.Application.Presences.PresenceGroups.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Presnces;

public class PresenceGroupController : ApiControllerBase
{
    [HttpPost("CreatePresenceGroup")]
    public async Task<ApplicationResponse> CreatePresenceGroup([FromBody] CreatePresenceGroupCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetPresenceGroups")]
    public async Task<ApplicationResponse> GetPresenceGroups([FromQuery] GetPresencesGroupsQuery request, CancellationToken cancellationToken)
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
    [HttpGet("GetPresenceGroupById")]
    public async Task<ApplicationResponse> GetPresenceGroupById([FromQuery] GetPresenceGroupByIdQuery request, CancellationToken cancellationToken)
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
    [HttpPost("EditPresenceGroup")]
    public async Task<ApplicationResponse> EditPresenceGroup([FromBody] EditPresenceGroupCommand request, CancellationToken cancellationToken)
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
    [HttpDelete("DeletePresenceGroup")]
    public async Task<ApplicationResponse> DeletePresenceGroup([FromBody] RemovePresenceGroupCommand request, CancellationToken cancellationToken)
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
    public async Task<ApplicationResponse> DeletePresenceGroup([FromQuery] PresenceDocumentsQuery request, CancellationToken cancellationToken)
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
