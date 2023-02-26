using CleanArchitecture.Application.Common.Dtos.Appllication;
using CleanArchitecture.Application.Common.Dtos.Report;
using CleanArchitecture.Application.Reports.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

[Authorize]
public class ReportController : ApiControllerBase
{
    [HttpGet("TransferReport")]
    [ProducesResponseType(typeof(ReportResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTransferReport([FromQuery] GetTransferReportQuery getTransferReportQuery, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(getTransferReportQuery);
        return Ok(result);
    }
    [HttpGet("RequestedServiceCategoriesReport")]
    [ProducesResponseType(typeof(ReportResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetRequestedServiceCategoriesReport([FromQuery] GetRequestedServiceCategoriesQuery getRequestedServiceCategoriesQuery, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(getRequestedServiceCategoriesQuery);
        return Ok(result);
    }
}
