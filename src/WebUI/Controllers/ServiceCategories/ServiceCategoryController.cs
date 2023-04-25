using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Roles.Queries;
using CleanArchitecture.Application.ServiceCategories.Commands;
using CleanArchitecture.Application.ServiceCategories.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.ServiceCategories;

public class ServiceCategoryController : ApiControllerBase
{
    [HttpPost("CreateServiceCategory")]
    public async Task<ApplicationResponse> CreateServiceCategory([FromBody] CreateServiceCategoryCommand request, CancellationToken cancellationToken)
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
    [HttpGet("ViewServiceCategories")]
    public async Task<ApplicationResponse> GetServiceCategories([FromQuery] GetServiceCategoryQuery request, CancellationToken cancellationToken)
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
    [HttpGet("ViewServiceCategoryById")]
    public async Task<ApplicationResponse> GetServiceCategoryById([FromQuery] ServiceCategoryByIdQuery request, CancellationToken cancellationToken)
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
    [HttpPost("EditServiceCategory")]
    public async Task<ApplicationResponse> EditServiceCategory([FromBody] EditServiceCategoryCommand request, CancellationToken cancellationToken)
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
    [HttpDelete("DeleteServiceCategory")]
    public async Task<ApplicationResponse> DeleteServiceCategory([FromBody] RemoveServiceCategoryCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetPersonnelCategories")]
    public async Task<ApplicationResponse> GetPersonnelCategories([FromQuery] PersonnelCategoriesQuery request, CancellationToken cancellationToken)
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
    //[HttpPost("AddRoles")]
    //public async Task<ApplicationResponse> AddRoles([FromBody] CreatePersonnelRole request, CancellationToken cancellationToken)
    //{
    //    var result = await Sender.Send(request, cancellationToken);
    //    return Ok(result);
    //}
    [HttpGet("GetPersonnelRoles")]
    public async Task<ApplicationResponse> GetPersonnelRoles([FromQuery] GetPersonnelRoleQuery request, CancellationToken cancellationToken)
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
    [HttpGet("GetAllApprovers")]
    public async Task<ApplicationResponse> GetAllApprovers([FromQuery] GetAllApproversQuery request, CancellationToken cancellationToken)
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