﻿using CleanArchitecture.Application.DocumentsTemplate.Queries;
using CleanArchitecture.Application.Roles.Commands;
using CleanArchitecture.Application.Roles.Queries;
using CleanArchitecture.Application.ServiceCategories.Commands;
using CleanArchitecture.Application.ServiceCategories.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.ServiceCategories;

public class ServiceCategoryController : ApiControllerBase
{
    [HttpPost("CreateServiceCategory")]
    public async Task<IActionResult> CreateServiceCategory([FromBody] CreateServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("ViewServiceCategories")]
    public async Task<IActionResult> GetServiceCategories([FromQuery] GetServiceCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("ViewServiceCategoryById")]
    public async Task<IActionResult> GetServiceCategoryById([FromQuery] ServiceCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("EditServiceCategory")]
    public async Task<IActionResult> EditServiceCategory([FromBody] EditServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpDelete("DeleteServiceCategory")]
    public async Task<IActionResult> DeleteServiceCategory([FromBody] RemoveServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetPersonnelCategories")]
    public async Task<IActionResult> GetPersonnelCategories([FromQuery] PersonnelCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("AddRoles")]
    public async Task<IActionResult> AddRoles([FromBody] CreatePersonnelRole request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetPersonnelRoles")]
    public async Task<IActionResult> GetPersonnelRoles([FromQuery] GetPersonnelRoleQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetAllApprovers")]
    public async Task<IActionResult> GetAllApprovers([FromQuery] GetAllApproversQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
}