using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.RequestDtos;
using CleanArchitecture.Application.Verisoft.Commands;
using CleanArchitecture.WebUI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;


[Route("api/[controller]")]
[TypeFilter(typeof(VerisoftUserCheckFilterAttribute))]
public class VerisoftController : ApiControllerBase
{
    [HttpPost("UpdateCustomer")]
    public async Task<IActionResult> UpdateCustomer([FromBody]UpdateVerisoftCustomerCommand updateCustomerCommand,CancellationToken cancellationToken)
    {
        var result = await Sender.Send(updateCustomerCommand, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost("SendNotification")]
    public async Task<IActionResult> SendNotification([FromBody]SendNotificationCommand sendNotificationCommand,CancellationToken cancellationToken)
    {
        var result = await Sender.Send(sendNotificationCommand, cancellationToken);
        return Ok(result);
    }
}
