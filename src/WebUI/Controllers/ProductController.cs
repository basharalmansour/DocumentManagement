
using CleanArchitecture.Application.Products.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
[Authorize]
public class ProductController : ApiControllerBase
{
    [HttpGet("GetProducts")]
    public async Task<IActionResult> GetProducts([FromQuery]GetProductsQuery getProductsQuery)
    {
        var result = await Sender.Send(getProductsQuery);
        return Ok(result);
    }
}
