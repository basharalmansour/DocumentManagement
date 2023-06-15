using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Personnels;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.Common.Dtos.VendorPersonnels;
using CleanArchitecture.Application.Common.Dtos.Vendors;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using CleanArchitecture.Application.VehicleTemplates.Commands;
using CleanArchitecture.Application.VehicleTemplates.Queries;
using CleanArchitecture.Application.Vendors.Commands;
using CleanArchitecture.Application.Vendors.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Vendors;

public class VendorController : ApiControllerBase
{
    [HttpPost("CreateVendor")]
    public async Task<ApplicationResponse<int>> CreateVendor([FromBody] CreateVendorCommand request, CancellationToken cancellationToken)
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
    [HttpPost("GetVendors")]
    public async Task<ApplicationResponse<TableResponseModel<BasicVendorDto>>> GetVendors([FromBody] GetVendorsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<BasicVendorDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<BasicVendorDto>>(e);
        }

    }
    [HttpGet("GetVendor")]
    public async Task<ApplicationResponse<GetVendorDto>> GetVendorById([FromQuery] GetVendorByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<GetVendorDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<GetVendorDto>(e);
        }

    }
    [HttpGet("GetVenderPersonnels")]
    public async Task<ApplicationResponse<TableResponseModel<GetVendorPersonnelDto>>> GetVenderPersonnels([FromBody] GetVendorPersonnelsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<GetVendorPersonnelDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<GetVendorPersonnelDto>>(e);
        }
    }
    [HttpPost("EditVendor")]
    public async Task<ApplicationResponse<int>> EditVendor([FromBody] EditVendorCommand request, CancellationToken cancellationToken)
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
    [HttpDelete("RemoveVendor")]
    public async Task<ApplicationResponse<bool>> RemoveVendor([FromBody] RemoveVendorCommand request, CancellationToken cancellationToken)
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
    [HttpPost("CreateUserDetails")]
    public async Task<ApplicationResponse<bool>> CreateUserDetails([FromBody] CreateUserCommand request, CancellationToken cancellationToken)
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