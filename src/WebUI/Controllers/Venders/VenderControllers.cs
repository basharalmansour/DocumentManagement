using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Personnels;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using CleanArchitecture.Application.VehicleTemplates.Commands;
using CleanArchitecture.Application.Venders.Commands;
using CleanArchitecture.Application.Venders.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Venders;

public class VenderControllers : ApiControllerBase
{
    [HttpPost("CreateVenderPersonnel")]
    public async Task<ApplicationResponse<bool>> CreateVenderPersonnel([FromBody] CreateVenderPersonnelCommand request, CancellationToken cancellationToken)
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
    [HttpGet("GetVenderPersonnels")]
    public async Task<ApplicationResponse<TableResponseModel<GetPersonnelDetailsDto>>> GetVenderPersonnels([FromBody] GetVenderPersonnelsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<TableResponseModel<GetPersonnelDetailsDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<TableResponseModel<GetPersonnelDetailsDto>>(e);
        }
    }
}