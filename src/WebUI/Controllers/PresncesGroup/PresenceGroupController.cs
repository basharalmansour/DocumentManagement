using CleanArchitecture.Application.PresenceGroups.Commands;
using CleanArchitecture.Application.PresenceGroups.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.PresncesGroup;

public class PresenceGroupController : ApiControllerBase
{
    [HttpPost("AddPresenceGroup")]
    public async Task<IActionResult> CreatePresenceGroup([FromBody] CreatePresenceGroupCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("ViewPresenceGroups")]
    public async Task<IActionResult> GetPresenceGroups([FromQuery] PresencesGroupQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("ViewPresenceGroupById")]
    public async Task<IActionResult> GetPresenceGroupById([FromQuery] PresenceGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("EditPresenceGroup")]
    public async Task<IActionResult> EditPresenceGroup([FromBody] EditPresenceGroupCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpDelete("DeletePresenceGroup")]
    public async Task<IActionResult> DeletePresenceGroup([FromBody] RemovePresenceGroupCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    public async Task<IActionResult> DeletePresenceGroup([FromQuery] PresenceDocumentsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }

}
