using CleanArchitecture.Application.Cities.Queries;
using CleanArchitecture.Application.Common.Dtos.POI.Portal;
using CleanArchitecture.Application.Countries.Queries;
using CleanArchitecture.Application.Districts.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
[Route("api/[controller]")]
 [AllowAnonymous]
public class CommonController : ApiControllerBase
{
    [Route("Countries")]
    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        var result = await Sender.Send(new GetCountriesQuery());
        return Ok(result);
    }
    [Route("Cities/{CountryId}")]
    [HttpGet]
    public async Task<IActionResult> GetCities([FromRoute]GetCitiesQuery getCitiesQuery)
    {
        var result = await Sender.Send(getCitiesQuery);
        return Ok(result);
    }

    [Route("Districts/{CityId}")]
    [HttpGet]
    public async Task<IActionResult> GetCities([FromRoute]GetDistrictsQuery getDistrictsQuery)
    {
        var result = await Sender.Send(getDistrictsQuery);
        return Ok(result);
    }
    [Route("PoiNationalities")]
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(NationalityResultDto),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPoiNationalities(CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetPOICountriesQuery());
        return Ok(result);
    }

}
