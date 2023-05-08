using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.VehicleTemplates.Commands;
using CleanArchitecture.Application.VehicleTemplates.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Vehicles;

public class VehicleController : ApiControllerBase
{
    [HttpPost("CreateVehicle")]
    public async Task<ApplicationResponse<int>> CreateVehicle([FromBody] CreateVehicleTemplateCommand request , CancellationToken cancellationToken)
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
    [HttpGet("GetVehicles")]
    public async Task<ApplicationResponse<List<BasicVehicleTemplateDto>>> GetVehicles([FromQuery] GetVehicleTemplateQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<List<BasicVehicleTemplateDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<List<BasicVehicleTemplateDto>>(e);
        }
        
    }
    [HttpGet("GetVehicle")]
    public async Task<ApplicationResponse<VehicleTemplateDto>> GetVehicleById([FromQuery] GetVehicleTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<VehicleTemplateDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<VehicleTemplateDto>(e);
        }
        
    }
    [HttpPost("EditVehicle")]
    public async Task<ApplicationResponse<int>> EditVehicle([FromBody] EditVehicleTemplateCommand request, CancellationToken cancellationToken)
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
    [HttpDelete("RemoveVehicle")]
    public async Task<ApplicationResponse<bool>> RemoveVehicle([FromBody] RemoveVehicleTemplateCommand request, CancellationToken cancellationToken)
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