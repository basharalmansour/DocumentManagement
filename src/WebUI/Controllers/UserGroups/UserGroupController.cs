using AutoWrapper.Wrappers;
using CleanArchitecture.Application.UsersGroup.Commands;
using CleanArchitecture.Application.UsersGroup.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.UserGroups;

public class UserGroupController : ApiControllerBase
{
    [HttpPost("CreateUserGroup")]
    public async Task<ApplicationResponse> CreateUserGroup([FromBody] CreateUserGroupCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetUserGroups")]
    public async Task<ApplicationResponse> GetUserGroups([FromQuery] GetUserGroupsQuery request, CancellationToken cancellationToken)
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
    [HttpGet("GetUserGroupById")]
    public async Task<ApplicationResponse> GetUserGroupById([FromQuery] GetUserGroupByIdQuery request, CancellationToken cancellationToken)
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
    [HttpPost("EditUserGroup")]
    public async Task<ApplicationResponse> EditUserGroup([FromBody] EditUserGroupCommand request, CancellationToken cancellationToken)
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
    [HttpDelete("DeleteUserGroup")]
    public async Task<ApplicationResponse> DeleteUserGroup([FromBody] RemoveUserGroupCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetUserGroupApprovers")]
    public async Task<ApplicationResponse> GetUserGroupApprovers([FromQuery] UserGroupApproversQuery request, CancellationToken cancellationToken)
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