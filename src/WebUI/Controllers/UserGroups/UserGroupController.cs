using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Personnels.Queries;
using CleanArchitecture.Application.UsersGroup.Commands;
using CleanArchitecture.Application.UsersGroup.Queries;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.UserGroups;

public class UserGroupController : ApiControllerBase
{
    [HttpPost("CreateUserGroup")]
    public async Task<ApplicationResponse<int>> CreateUserGroup([FromBody] CreateUserGroupCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetUserGroups")]
    public async Task<ApplicationResponse<TableResponseModel<GetUserGroupDto>>> GetUserGroups([FromQuery] GetUserGroupsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<GetUserGroupDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<GetUserGroupDto>>(e);
        }
    }
    [HttpGet("GetUserGroupById")]
    public async Task<ApplicationResponse<GetUserGroupDto>> GetUserGroupById([FromQuery] GetUserGroupByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<GetUserGroupDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<GetUserGroupDto>(e);
        }
    }
    [HttpPost("EditUserGroup")]
    public async Task<ApplicationResponse<int>> EditUserGroup([FromBody] EditUserGroupCommand request, CancellationToken cancellationToken)
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
    [HttpDelete("DeleteUserGroup")]
    public async Task<ApplicationResponse<bool>> DeleteUserGroup([FromBody] RemoveUserGroupCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetUserGroupApprovers")]
    public async Task<ApplicationResponse<TableResponseModel<UserGroupApproversDto>>> GetUserGroupApprovers([FromQuery] GetUserGroupApproversQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<UserGroupApproversDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<UserGroupApproversDto>>(e);
        }
    }
    [HttpGet("GetPersonnelRoles")]
    public async Task<ApplicationResponse<TableResponseModel<Role>>> GetPersonnelRoles([FromQuery] GetPersonnelRoleQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<Role>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<Role>>(e);
        }
    }
}