using CleanArchitecture.Application.DocumentsTemplate.Queries;
using CleanArchitecture.Application.Rules.Commands;
using CleanArchitecture.Application.Rules.Queries;
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
    [HttpPost("AddRules")]
    public async Task<IActionResult> AddRules([FromBody] CreatePersonnelRule request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetPersonnelRules")]
    public async Task<IActionResult> GetPersonnelRules([FromQuery] GetPersonnelRuleQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
}