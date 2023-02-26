using CleanArchitecture.Application.Basket.Commands;
using CleanArchitecture.Application.Common.Dtos.Appllication;
using CleanArchitecture.Application.Common.Dtos.Basket;
using CleanArchitecture.Application.Common.Dtos.POI.Cart.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.POI.Cart.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.POI.Transfer.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.POI.Transfer.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.Products;
using CleanArchitecture.Application.Common.Dtos.Transfer;
using CleanArchitecture.Application.IntegrationServices.Commands;
using CleanArchitecture.Application.IntegrationServices.Queries;
using CleanArchitecture.Application.Products.Queries;
using CleanArchitecture.WebUI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

[Authorize]
public class IntegrationServices : ApiControllerBase
{

    [HttpGet("TransferZones")]
    [ProducesResponseType(typeof(List<TransferZoneDto>),200)]
    public async Task<IActionResult> GetTransferZones(CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetTransferServiceZonesQuery(),cancellationToken);
        return Ok(result);
    }
    [HttpGet("TransferStartPoints")]
    [ProducesResponseType(typeof(List<TransferStartPointDto>), 200)]
    public async Task<IActionResult> GetTransferStartPoints([FromQuery]GetTransferStartPointListQuery getTransferStartPointListQuery, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(getTransferStartPointListQuery,cancellationToken);
        return Ok(result);
    }
    [HttpGet("TransferEndPoints")]
    [ProducesResponseType(typeof(List<TransferEndPointDto>), 200)]
    public async Task<IActionResult> GetTransferEndPoints([FromQuery]GetTransferEndPointListQuery getTransferEndPointListQuery, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(getTransferEndPointListQuery,cancellationToken);
        return Ok(result);
    }
    [HttpPost("SearchTransfer")]
    [ProducesResponseType(typeof(TransferSearchResultDto), 200)]
    public async Task<IActionResult> SearchTransfer([FromBody]TransferSearchRequestDto transferSearchRequestDto,CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new TransferSearchQuery()
        {
            TransferSearchRequestDto = transferSearchRequestDto
        },cancellationToken);
        return Ok(result);
    }
    [HttpPost("CreateReservation")]
    [ProducesResponseType(typeof(CartTransferResultDto), 200)] 
    public async Task<IActionResult> CartTransfer([FromBody] PreCheckoutTransferCommand preCheckoutTransferCommand,CancellationToken cancellationToken =default)
    {
        var result = await Sender.Send(preCheckoutTransferCommand);
        return Ok(result);
    }
    [HttpPost("CreateOrder")]
    [ProducesResponseType(typeof(CreateTransferOrderResponseDto), 200)] 
    public async Task<IActionResult> CheckoutTransfer([FromBody] CheckoutTransferCommand checkoutTransferCommand, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(checkoutTransferCommand, cancellationToken);
        return Ok(result);
    }
    [HttpPost("CancelTransfer")]
    [ProducesResponseType(typeof(CancelTransferResultDto), 200)]
    public async Task<IActionResult> CancelTransfer([FromBody] TransferCancelRequestDto transferCancelRequestDto,CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new CancelTransferCommand()
        {
            CancelTransferDto = transferCancelRequestDto,
        },cancellationToken);
        return Ok(result);
    }
    [HttpPost("UpdateTransfer")]
    [ProducesResponseType(typeof(UpdateTransferResult), 200)]
    public async Task<IActionResult> UpdateTransfer([FromBody] TransferSaveRequestDto transferSaveRequestDto,CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new UpdateTransferCommand()
        {
            UpdateTransferDto = transferSaveRequestDto,
        },cancellationToken);
        return Ok(result);
    }
    [HttpGet("Basket")]
    [ProducesResponseType(typeof(GetBasketDto),200)]
    public async Task<IActionResult> GetBasket()
    {
        var result = await Sender.Send(new GetTransferBasketQuery());
        return Ok(result);
    }
    [HttpPost("RemoveTransferFromBasket")]
    [ProducesResponseType(typeof(RemoveTransferFromBasketResultDto), 200)]
    [ProducesResponseType(typeof(ErrorResponseModel), 404)]
    public async Task<IActionResult> DeleteTransferFromBasket(RemoveBasketCommand removeBasketCommand)
    {
        var result = await Sender.Send(removeBasketCommand);
        return Ok(result);
    }
    [HttpPost("AddInvoiceAddress")]
    [ProducesResponseType(typeof(AddInvoiceAddressResultDto), 200)]
    [ProducesResponseType(typeof(ErrorResponseModel), 404)]
    [ProducesResponseType(typeof(ErrorResponseModel), 400)]
    [ProducesResponseType(typeof(ErrorResponseModel), 400)] 
    public async Task<IActionResult> addInvoice(AddInvoiceCommand addInvoiceCommand,CancellationToken cancellationToken)
    {
        var result = await Sender.Send(addInvoiceCommand, cancellationToken);
        return Ok(result);
    }
}
