using CleanArchitecture.Application.Common.Dtos.Appllication;
using CleanArchitecture.Application.Common.Dtos.Customer;
using CleanArchitecture.Application.Common.Dtos.POI.Rights;
using CleanArchitecture.Application.Common.Dtos.QrCode;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.ResponseDtos;
using CleanArchitecture.Application.Customer.Commands;
using CleanArchitecture.Application.Customer.Queries;
using CleanArchitecture.Application.IntegrationServices.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

[Authorize]
public class CustomerController : ApiControllerBase
{
    [HttpGet("CheckUser")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CheckCustomerResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CheckUser([FromQuery] CheckCustomerQuery checkCustomerQuery, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(checkCustomerQuery, cancellationToken);
        return Ok(result);
    }
    [HttpPost("CreateIntegrationUser")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CreateIntegrationUserResulDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateUser([FromBody] CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(createCustomerCommand);
        return Ok(result);
    }
    
    [HttpGet("GetUserInfo")]
    [ProducesResponseType(typeof(GetIntegrationCustomerRegisterInfoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomerInfo([FromQuery] GetCustomerInfoQuery getCustomerInfoQuery, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(getCustomerInfoQuery, cancellationToken);
        return Ok(result);
    }
    [HttpGet("Rights")]
    [ProducesResponseType(typeof(GetPoiUserRights),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRights([FromQuery]GetCustomerRightsQuery getCustomerRightsQuery)
    {
        var result = await Sender.Send(getCustomerRightsQuery);
        return Ok(result);
    }
    [HttpGet("GetQrPass")]
    [ProducesResponseType(typeof(QrCodeResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetQrdata([FromQuery]GetQrDataQuery generateQrQuery, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(generateQrQuery, cancellationToken);
        return Ok(result);
    }
    [HttpPost("SendOtpMessage")]
    [ProducesResponseType(typeof(SendOtpMessageResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)] 
    [AllowAnonymous]
    public async Task<IActionResult> SendOtp([FromBody]SendOtpToCustomerCommand sendOtpToCustomerCommand, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(sendOtpToCustomerCommand, cancellationToken);
        return Ok(result);
    }
    [ProducesResponseType(typeof(GetIntegrationCustomerRegisterInfoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
    [HttpPost("ConfirmOtpMessage")]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmOtpMessage([FromBody]ConfirmOtpCommand confirmOtpCommand, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(confirmOtpCommand, cancellationToken);
        return Ok(result);
    }
    [ProducesResponseType(typeof(List<GetCustomerAdvantagesDto>),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel),StatusCodes.Status404NotFound)]
    [HttpGet("Advantages")]
    public async Task<IActionResult> GetCusomerAdvantages([FromQuery]GetCustomerAdvantagesQuery getCustomerAdvantagesQuery)
    {
        var result = await Sender.Send(getCustomerAdvantagesQuery);
        return Ok(result);
    }
    [HttpGet("CheckCustomerBy")]
    [ProducesResponseType(typeof(CheckCustomerByResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CheckCustomerBy([FromQuery] CheckCustomerByQuery checkCustomerByQuery, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(checkCustomerByQuery, cancellationToken);
        return Ok(result);
    }
}
