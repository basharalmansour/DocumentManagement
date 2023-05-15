using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Orders.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Orders;
public class OrderController : ApiControllerBase
{
    [HttpGet("GetOrderAvailableTimes")]
    public async Task<ApplicationResponse<OrderAvailableTimesDto>> GetOrderAvailableTimes([FromQuery] GetOrderAvailableTimesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<OrderAvailableTimesDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<OrderAvailableTimesDto>(e);
        }
    }
}
