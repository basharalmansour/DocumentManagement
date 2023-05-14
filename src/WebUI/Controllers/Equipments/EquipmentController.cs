using CleanArchitecture.Application.Common.Dtos.Equipments;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Equipments.Query;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Application.Forms.Queries;
using CleanArchitecture.Domain.Common;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers.Equipments;

public class EquipmentController : ApiControllerBase
{
    [HttpPost("GetEquipmentSpecialRules")]
    public async Task<ApplicationResponse<EquipmentDto>> GetEquipmentSpecialRules([FromQuery] GetEquipmentSpecialRulesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Sender.Send(request, cancellationToken);
            return new ApplicationResponse<EquipmentDto>(result);
        }
        catch (Exception e)
        {
            return new ApplicationResponse<EquipmentDto>(e);
        }
    }
}