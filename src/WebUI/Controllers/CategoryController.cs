using CleanArchitecture.Application.Categories.Queries;
using CleanArchitecture.Application.Common.Dtos.Category;
using CleanArchitecture.Application.Common.Dtos.Products;
using CleanArchitecture.Application.Products.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
[Authorize]
public class CategoryController : ApiControllerBase
{

    [HttpGet("GetCategories")]
    [ProducesResponseType(typeof(List<GetCategoryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories()
    {
        var result = await Sender.Send(new GetCategoriesQuery());
        return Ok(result);
    }


}
