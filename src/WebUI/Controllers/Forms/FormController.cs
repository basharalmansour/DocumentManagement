using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Application.Forms.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Forms;

public class FormController : ApiControllerBase
{
    [HttpPost("CreateForm")]
    public async Task<IActionResult> CreateForm([FromBody] CreateFormCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetForms")]
    public async Task<IActionResult> GetForms([FromQuery] GetFormsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("GetFormById")]
    public async Task<IActionResult> GetFormById([FromQuery] GetFormByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("EditForm")]
    public async Task<IActionResult> EditForm([FromBody] EditFormCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpDelete("DeleteForm")]
    public async Task<IActionResult> DeleteForm([FromBody] RemoveFormCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
}
