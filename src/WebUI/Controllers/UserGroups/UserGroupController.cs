using CleanArchitecture.Application.UsersGroup.Commands;
using CleanArchitecture.Application.UsersGroup.Queries;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.UserGroups;

public class UserGroupController : ApiControllerBase
{
    [HttpPost("AddUserGroup")]
    public async Task<IActionResult> CreateUserGroup([FromBody] CreateUserGroupCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("ViewUserGroups")]
    public async Task<IActionResult> GetUserGroups([FromQuery] GetUserGroupQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("ViewUserGroupById")]
    public async Task<IActionResult> GetUserGroupById([FromQuery] UserGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("EditUserGroup")]
    public async Task<IActionResult> EditUserGroup([FromBody] EditUserGroupCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpDelete("DeleteUserGroup")]
    public async Task<IActionResult> DeleteUserGroup([FromBody] RemoveUserGroupCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetUserGroupApprovers")]
    public async Task<IActionResult> GetUserGroupApprovers([FromQuery] UserGroupApproversQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
}