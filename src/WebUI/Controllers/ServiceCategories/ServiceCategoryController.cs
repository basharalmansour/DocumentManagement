using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.UserGroup;
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
    [HttpGet("GetServiceCategoryById")]
    public async Task<ApplicationResponse<ServiceCategoryDto>> GetServiceCategoryById([FromQuery] GetServiceCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<ServiceCategoryDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<ServiceCategoryDto>(e);
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
    public async Task<ApplicationResponse<OrderTimesDto>> GetOrderTimesQuery([FromQuery] GetOrderTimesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<OrderTimesDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<OrderTimesDto>(e);
        }
    }
    [HttpGet("GetServiceCategoryDocuments")]
    public async Task<ApplicationResponse<TableResponseModel<BasicDocumentTemplateDto>>> GetServiceCategoryDocuments([FromQuery] GetServiceCategoryDocumentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<BasicDocumentTemplateDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<BasicDocumentTemplateDto>>(e);
        }
    }
    [HttpGet("GetServiceCategoryPersonnelDocuments")]
    public async Task<ApplicationResponse<TableResponseModel<BasicDocumentTemplateDto>>> GetServiceCategoryPersonnelDocuments([FromQuery] GetServiceCategoryPersonnelDocumentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<BasicDocumentTemplateDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<BasicDocumentTemplateDto>>(e);
        }
    }
    [HttpGet("GetMaxPersonnelCount")]
    public async Task<ApplicationResponse<int>> GetMaxPersonnelCount([FromQuery] GetMaxPersonnelCountQuery request, CancellationToken cancellationToken)
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
}