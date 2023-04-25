﻿using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Vehicles.Commands;
using CleanArchitecture.Application.Vehicles.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Vehicles;

public class VehicleController : ApiControllerBase
{
    [HttpPost("AddVehicle")]
    public async Task<ApplicationResponse> CreateVehicle([FromBody] CreateVehicleCommand request , CancellationToken cancellationToken)
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
    [HttpGet("ViewVehicles")]
    public async Task<ApplicationResponse> GetVehicles([FromQuery] GetVehicleQuery request, CancellationToken cancellationToken)
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
    public async Task<ApplicationResponse> GetVehicleById([FromQuery] GetVehicleByIdQuery request, CancellationToken cancellationToken)
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
    public async Task<ApplicationResponse> EditVehicle([FromBody] EditVehicleCommand request, CancellationToken cancellationToken)
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
    [HttpDelete("DeleteVehicle")]
    public async Task<ApplicationResponse> DeleteVehicle([FromBody] RemoveVehicleCommand request, CancellationToken cancellationToken)
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