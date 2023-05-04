using AutoWrapper.Wrappers;
using CleanArchitecture.Application.VehicleTemplates.Commands;
using CleanArchitecture.Application.VehicleTemplates.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Vehicles;

public class VehicleController : ApiControllerBase
{
    [HttpPost("CreateVehicle")]
    public async Task<ApplicationResponse> CreateVehicle([FromBody] CreateVehicleTemplateCommand request , CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
        
    }
    [HttpGet("GetVehicles")]
    public async Task<ApplicationResponse> GetVehicles([FromQuery] GetVehicleTemplateQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
        
    }
    [HttpGet("GetVehicle")]
    public async Task<ApplicationResponse> GetVehicleById([FromQuery] GetVehicleTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
        
    }
    [HttpPost("EditVehicle")]
    public async Task<ApplicationResponse> EditVehicle([FromBody] EditVehicleTemplateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
        
    }
    [HttpDelete("RemoveVehicle")]
    public async Task<ApplicationResponse> RemoveVehicle([FromBody] RemoveVehicleTemplateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse(e);
        }
        
    }
}