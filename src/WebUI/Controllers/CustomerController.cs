using CleanArchitecture.Application.Common.Dtos.Appllication;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Customer.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

[Authorize]
public class CustomerController : ApiControllerBase
{
    [HttpPost("SendOtpMessage")]
    [ProducesResponseType(typeof(SendOtpMessageResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)] 
    [AllowAnonymous]
    public async Task<IActionResult> SendOtp([FromBody]SendOtpToCustomerCommand sendOtpToCustomerCommand, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(sendOtpToCustomerCommand, cancellationToken);
        return Ok(result);
    }
}
