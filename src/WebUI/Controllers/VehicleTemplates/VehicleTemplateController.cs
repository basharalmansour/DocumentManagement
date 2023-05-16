using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.VehicleTemplates.Commands;
using CleanArchitecture.Application.VehicleTemplates.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.VehicleTemplates;

public class VehicleTemplateController : ApiControllerBase
{
    [HttpPost("CreateVehicleTemplate")]
    public async Task<ApplicationResponse<int>> CreateVehicleTemplate([FromBody] CreateVehicleTemplateCommand request , CancellationToken cancellationToken)
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
    [HttpGet("GetVehicleTemplates")]
    public async Task<ApplicationResponse<TableResponseModel<BasicVehicleTemplateDto>>> GetVehicleTemplates([FromQuery] GetVehicleTemplateQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<BasicVehicleTemplateDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<BasicVehicleTemplateDto>>(e);
        }
        
    }
    [HttpGet("GetVehicleTemplate")]
    public async Task<ApplicationResponse<VehicleTemplateDto>> GetVehicleTemplateById([FromQuery] GetVehicleTemplateByIdQuery request, CancellationToken cancellationToken)
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
    [HttpPost("EditVehicleTemplate")]
    public async Task<ApplicationResponse<int>> EditVehicleTemplate([FromBody] EditVehicleTemplateCommand request, CancellationToken cancellationToken)
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
    [HttpDelete("RemoveVehicleTemplate")]
    public async Task<ApplicationResponse<bool>> RemoveVehicleTemplate([FromBody] RemoveVehicleTemplateCommand request, CancellationToken cancellationToken)
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