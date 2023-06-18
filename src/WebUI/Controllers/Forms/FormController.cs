using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Application.Forms.Queries;
using CleanArchitecture.Domain.Common;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Forms;

[Authorize]
public class FormController : ApiControllerBase
{
    [HttpPost("CreateForm")]
    public async Task<ApplicationResponse<int>> CreateForm([FromBody] CreateFormCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<int>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<int>(e);
        }
    }
    [HttpGet("GetForms")]
    public async Task<ApplicationResponse<TableResponseModel<BasicFormDto>>> GetForms([FromQuery] GetFormsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<BasicFormDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<BasicFormDto>>(e);
        }
    }
    [HttpGet("GetFormById")]
    public async Task<ApplicationResponse<FormDto>> GetFormById([FromQuery] GetFormByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<FormDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<FormDto>(e);
        }
    }
    [HttpPost("EditForm")]
    public async Task<ApplicationResponse<int>> EditForm([FromBody] EditFormCommand request, CancellationToken cancellationToken)
    {
        try
        {
            int result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<int>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<int>(e);
        }
    }
    [HttpDelete("DeleteForm")]
    public async Task<ApplicationResponse<bool>> DeleteForm([FromBody] RemoveFormCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<bool>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<bool>(e);
        }
    }
}
