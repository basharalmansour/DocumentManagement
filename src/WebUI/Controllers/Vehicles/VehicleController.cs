using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Application.Vehicles.Queries;
using CleanArchitecture.Application.VehicleTemplates.Commands;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Vehicles;

public class VehicleController : ApiControllerBase
{
    [HttpGet("GetVehicles")]
    public async Task<ApplicationResponse<TableResponseModel<VehicleDto>>> GetVehicles([FromBody] GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<VehicleDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<VehicleDto>>(e);
        }

    }
}
