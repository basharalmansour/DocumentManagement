using CleanArchitecture.Application.Common.Dtos.Hotel.Arrival.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Arrival.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Offer.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Offer.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.OfferDetail.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.OfferDetail.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Price;
using CleanArchitecture.Application.Common.Dtos.Hotel.Price.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Product.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.Hotel.Product.ResponseDtos;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IHotelHttpClient
{
    Task<GetArrivalAutoCompleteResponseDto> GetArrivalAutoComplete(GetArrivalAutoCompleteRequestDto requestDto, CancellationToken cancellationToken = default);
    Task<GetProductInfoResponseDto> GetProductInfo(GetProductInfoRequestDto requestDto, CancellationToken cancellationToken = default);
    Task<GetOffersResponseDto> GetOffers(GetOffersRequestDto requestDto, CancellationToken cancellationToken = default);
    Task<GetOfferDetailsResponseDto> GetOfferDetails(GetOfferDetailsRequestDto requestDto, CancellationToken cancellationToken = default);
    Task<PriceSearchResponseDto> PriceSearchHotel(PriceSearchHotelRequestDto requestDto, CancellationToken cancellationToken = default);
    Task<PriceSearchResponseDto> PriceSearchLocation(PriceSearchLocationRequestDto requestDto, CancellationToken cancellationToken = default);
}