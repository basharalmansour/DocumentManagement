using CleanArchitecture.Application.IntegrationParameters.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class IntegrationParametersController : ApiControllerBase
{

    [HttpGet("LoadIntegrationCountries")]
    public async Task<IActionResult> LoadIntegrationCountries(CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new LoadIntegrationCountriesCommand());
        return Ok(result);
    }
}
