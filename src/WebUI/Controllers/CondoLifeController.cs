using CleanArchitecture.Application.Common.Dtos.CondoLife;
using CleanArchitecture.Application.CondoLife.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

[Authorize]
public class CondoLifeController : ApiControllerBase
{
    [HttpPost("UpdateUser")]
    public async Task<IActionResult> UpdateUser(UpdateCondolifeUserCommand updateCondolifeUserCommand,CancellationToken cancellationToken)
    {
        var result = await Sender.Send(updateCondolifeUserCommand, cancellationToken);
        return Ok(result);
    }
}
