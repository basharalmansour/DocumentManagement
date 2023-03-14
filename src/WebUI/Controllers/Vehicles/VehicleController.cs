using CleanArchitecture.Application.Vehicles.Commands;
using CleanArchitecture.Application.Vehicles.Queries;
using MassTransit.Internals.GraphValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Vehicles;

public class VehicleController : ApiControllerBase
{
    [HttpPost("AddVehicle")]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleCommand request , CancellationToken cancellationToken)
    {
        var result=  await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpGet("ViewVehicles")]
    public async Task<IActionResult> GetVehicles([FromQuery] GetVehicleQuery request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpPost("EditVehicle")]
    public async Task<IActionResult> EditVehicle([FromBody] EditVehicleCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
    [HttpDelete("DeleteVehicle")]
    public async Task<IActionResult> DeleteVehicle([FromBody] RemoveVehicleCommand request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Ok(result);
    }
}