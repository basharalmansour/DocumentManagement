using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
using CleanArchitecture.Application.Personnels.Queries;
using CleanArchitecture.Application.Personnels.Queries;
using CleanArchitecture.Application.ServiceCategories.Commands;
using CleanArchitecture.Application.ServiceCategories.Queries;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.ServiceCategories;

public class ServiceCategoryController : ApiControllerBase
{
    [HttpPost("CreateServiceCategory")]
    public async Task<ApplicationResponse<int>> CreateServiceCategory([FromBody] CreateServiceCategoryCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetServiceCategories")]
    public async Task<ApplicationResponse<TableResponseModel<BasicServiceCategoryDto>>> GetServiceCategories([FromQuery] GetServiceCategoryQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<BasicServiceCategoryDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<BasicServiceCategoryDto>>(e);
        }
    }
    [HttpGet("ViewServiceCategoryById")]
    public async Task<ApplicationResponse<ServiceCategoryDetailsDto>> GetServiceCategoryById([FromQuery] GetServiceCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<ServiceCategoryDetailsDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<ServiceCategoryDetailsDto>(e);
        }
    }
    [HttpPost("EditServiceCategory")]
    public async Task<ApplicationResponse<int>> EditServiceCategory([FromBody] EditServiceCategoryCommand request, CancellationToken cancellationToken)
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
    [HttpDelete("DeleteServiceCategory")]
    public async Task<ApplicationResponse<bool>> DeleteServiceCategory([FromBody] RemoveServiceCategoryCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetPersonnelCategories")]
    public async Task<ApplicationResponse<UserGroupApproversDto>> GetPersonnelCategories([FromQuery] GetPersonnelCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<UserGroupApproversDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<UserGroupApproversDto>(e);
        }
    }
    //[HttpPost("AddRoles")]
    //public async Task<ApplicationResponse> AddRoles([FromBody] CreatePersonnelRole request, CancellationToken cancellationToken)
    //{
    //    var result = await Sender.Send(request, cancellationToken);
    //    return Ok(result);
    //}
    [HttpGet("GetPersonnelRoles")]
    public async Task<ApplicationResponse<List<Role>>> GetPersonnelRoles([FromQuery] GetPersonnelRoleQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<List<Role>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<List<Role>>(e);
        }
    }

}