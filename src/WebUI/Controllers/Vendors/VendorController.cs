using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Personnels;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.VendorPersonnels;
using CleanArchitecture.Application.Common.Dtos.Vendors;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using CleanArchitecture.Application.VehicleTemplates.Commands;
using CleanArchitecture.Application.Vendors.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Vendors;

public class VendorController : ApiControllerBase
{
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
}