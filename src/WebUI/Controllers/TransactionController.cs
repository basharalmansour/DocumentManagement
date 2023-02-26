using CleanArchitecture.Application.Common.Dtos.Appllication;
using CleanArchitecture.Application.Common.Dtos.Orders;
using CleanArchitecture.Application.Common.Dtos.Transactions;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Transactions.Queries;
using CleanArchitecture.Domain.Entities.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
[Authorize]
public class TransactionController : ApiControllerBase
{
    [HttpGet("Transactions")]
    [ProducesResponseType(typeof(List<GetTransactionsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTransactions([FromQuery] GetCustomerTransactionsQuery getCustomerTransactionsQuery, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(getCustomerTransactionsQuery, cancellationToken);
        return Ok(result);
    }
    [HttpGet("PassedTransactions")]
    [ProducesResponseType(typeof(List<GetPassedTransactionDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPassedTransactions([FromQuery]GetPassedTransactionsQuery getPassedTransactionsQuery)
    {
        var result = await Sender.Send(getPassedTransactionsQuery);
        return Ok(result);
    }
    
    [HttpGet("PassedTransactionsForCms")]
    [ProducesResponseType(typeof(List<GetPassedTransactionDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPassedTransactionsForCms([FromQuery]GetPassedTransactionsQuery getPassedTransactionsQuery)
    {
        var result = await Sender.Send(getPassedTransactionsQuery);
        return Ok(result);
    }

    [HttpGet("TransactionDetail")]
    [ProducesResponseType(typeof(GetTransactionDetailDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTransactionDetail([FromQuery]GetCustomerTransactionDetailQuery getCustomerTransactionDetailQuery,CancellationToken cancellationToken)
    {
        var result = await Sender.Send(getCustomerTransactionDetailQuery, cancellationToken);
        return Ok(result);
    }

    [HttpPost("OrderPropertyDetailFilter")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedList<OrderPropertyDetailsDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrderPropertyDetails([FromBody] GetOrderPropertyDetailQuery query, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(query, cancellationToken);
        return Ok(result);
    }

}
