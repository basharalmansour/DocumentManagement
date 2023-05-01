using AutoWrapper.Wrappers;
using CleanArchitecture.Application.Personnels.Queries;
using CleanArchitecture.Application.Presences.PresenceGroups.Queries;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Commands;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Personnels;
public class PersonnelController : ApiControllerBase
{
    [HttpGet("GetAllApprovers")]
    public async Task<ApplicationResponse> GetAllApprovers([FromQuery] GetPersonnelsQuery request, CancellationToken cancellationToken)
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