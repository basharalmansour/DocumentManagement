using CleanArchitecture.Application.Common.Dtos.Hotel.Arrival.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Offer.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.OfferDetail.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Price;
using CleanArchitecture.Application.Common.Dtos.Hotel.Product.ResponseDtos;
using CleanArchitecture.Application.Hotel.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class HotelController : ApiControllerBase
{
    [HttpPost("GetArrivalAutoComplete")]
    [ProducesResponseType(typeof(GetArrivalAutoCompleteResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetArrivalAutoComplete([FromBody] GetArrivalAutoCompleteQuery query, CancellationToken cancellationToken)
        => Ok(await Sender.Send(query, cancellationToken));


    [HttpPost("PriceSearchLocation")]
    [ProducesResponseType(typeof(PriceSearchResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> PriceSearchLocation([FromBody] PriceSearchLocationQuery query, CancellationToken cancellationToken)
        => Ok(await Sender.Send(query, cancellationToken));


    [HttpPost("PriceSearchHotel")]
    [ProducesResponseType(typeof(PriceSearchResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> PriceSearchHotel([FromBody] PriceSearchHotelQuery query, CancellationToken cancellationToken)
        => Ok(await Sender.Send(query, cancellationToken));


    [HttpPost("GetProductInfo")]
    [ProducesResponseType(typeof(GetProductInfoResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductInfo([FromBody] GetProductInfoQuery query, CancellationToken cancellationToken)
        => Ok(await Sender.Send(query, cancellationToken));


    [HttpPost("GetOffers")]
    [ProducesResponseType(typeof(GetOffersResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOffers([FromBody] GetOffersQuery query, CancellationToken cancellationToken)
        => Ok(await Sender.Send(query, cancellationToken));


    [HttpPost("GetOfferDetails")]
    [ProducesResponseType(typeof(GetOfferDetailsResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOffers([FromBody] GetOfferDetailsQuery query, CancellationToken cancellationToken)
        => Ok(await Sender.Send(query, cancellationToken));
}