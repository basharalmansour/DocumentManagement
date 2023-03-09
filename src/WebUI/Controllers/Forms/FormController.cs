using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Application.Forms.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Forms;

public class FormController : ApiControllerBase
{
    [HttpPost("AddForm")]
    public async Task<IActionResult> CreateForm([FromBody] CreateFormCommnad request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("ViewForms")]
    public async Task<IActionResult> GetForms([FromBody] GetFormsQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("ViewFormById")]
    public async Task<IActionResult> GetFormById([FromBody] GetFormByIdQuery request, CancellationToken cancellationToken)
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
