using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Common.Dtos.Personnels;
using CleanArchitecture.Application.Personnels.Queries;
using CleanArchitecture.Application.Presences.PresenceGroups.Queries;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Personnels;
public class PersonnelController : ApiControllerBase
{
    [HttpGet("GetPersonnels")]
    public async Task<ApplicationResponse<List<GetPersonnelDetailsDto>>> GetPersonnels([FromQuery] GetPersonnelsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<List<GetPersonnelDetailsDto>>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<List<GetPersonnelDetailsDto>>(e);
        }
    }
}