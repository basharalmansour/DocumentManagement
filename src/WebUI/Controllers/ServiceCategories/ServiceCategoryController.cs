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
    public async Task<IActionResult> GetServiceCategories([FromBody] GetServiceCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("ViewServiceCategoryById")]
    public async Task<IActionResult> GetServiceCategoryById([FromBody] ServiceCategoryByIdQuery request, CancellationToken cancellationToken)
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
}