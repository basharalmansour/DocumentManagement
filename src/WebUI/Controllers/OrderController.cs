using CleanArchitecture.Application.Common.Dtos.Orders;
using CleanArchitecture.Application.Orders.Commands;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.WebUI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.WebUI.Controllers;


[Authorize]
public class OrderController : ApiControllerBase
{
    private readonly string _setOrderStatusKey;
    public OrderController(IOptions<AppSettings> options)
    {
        _setOrderStatusKey = options.Value.ClientSettings.CondoLife.ClientKey;
    }
    [HttpPost("PrepareCartOrder")]
    [ProducesResponseType(typeof(CreateCartOrderResultDto),200)]
    public async Task<IActionResult> Create(CreateCartOrderCommand createOrderCommand,CancellationToken cancellationToken)
    {
        var result = await Sender.Send(createOrderCommand,cancellationToken);
        return Ok(result);
    }
    [HttpPost("SetOrderStatus")] 
    [AllowAnonymous]
    [ProducesResponseType(typeof(SetOrderStatusResponseDto),200)]
    public async Task<IActionResult> SetOrderStatus(SetOrderStatusDto setOrderStatusDto, CancellationToken cancellationToken)
    {
        if(setOrderStatusDto.Key != _setOrderStatusKey)
        {
            return Unauthorized();
        }
        var result = await Sender.Send(new SetOrderStatusCommand()
        {
            SetOrderStatusDto = setOrderStatusDto
        },cancellationToken);
        return Ok( result);
    }
}
