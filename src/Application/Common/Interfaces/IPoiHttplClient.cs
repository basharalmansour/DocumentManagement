using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.POI;
using CleanArchitecture.Application.Common.Dtos.POI.Cart.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.POI.Cart.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.POI.Portal;
using CleanArchitecture.Application.Common.Dtos.POI.Rights;
using CleanArchitecture.Application.Common.Dtos.POI.Transfer.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.POI.Transfer.ResponseDtos;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IPoiHttplClient
{
    Task<bool> CancelTransferAsync(TransferCancelRequestDto transferCancelRequestDto, GetPOIAuthKeyRequestDto getPOIAutKeyRequestDto, CancellationToken cancellationToken = default);
    Task<bool> SaveTransferAsync(TransferSaveRequestDto transferSaveRequestDto, GetPOIAuthKeyRequestDto getPOIAutKeyRequestDto, CancellationToken cancellationToken = default);
    Task<TransferSearchResultDto> SearchTransferAsync(TransferSearchRequestDto transferSearchRequestDto,GetPOIAuthKeyRequestDto getPOIAutKeyRequestDto, CancellationToken cancellationToken = default);
    Task<List<TransferZoneDto>> TransferZoneListAsync(CancellationToken cancellationToken = default);
    Task<List<TransferStartPointDto>> TransferStartPointListAsync(int zoneId, CancellationToken cancellationToken = default);
    Task<List<TransferEndPointDto>> TransferEndPointListAsync(string startPoint, CancellationToken cancellationToken = default);
    Task<CartTransferResultDto> CartTransferAsync(CartTransferRequestDto cartTransferRequestDto, GetPOIAuthKeyRequestDto getPOIAutKeyRequestDto, CancellationToken cancellationToken = default);
    Task<CartCheckOutTransferResultDto> CheckoutTransferAsync(CartCheckOutTransferRequestDto cartCheckOutTransferRequestDto, GetPOIAuthKeyRequestDto getPOIAutKeyRequestDto, CancellationToken cancellationToken = default);
    Task<PortalResultDto> GetPortal(CancellationToken cancellationToken = default);
    Task<TransferListResultDto> TransferListAsync(GetPOIAuthKeyRequestDto getPOIAutKeyRequestDto, DateTime startDate = default, DateTime endDate = default, int page = 0, string type = null, CancellationToken cancellationToken = default);
    Task<GetPoiUserRights> Rights(GetPOIAuthKeyRequestDto getPOIAutKeyRequestDto, CancellationToken cancellationToken = default);
    Task<List<NationalityResultDto>> GetNationalities(CancellationToken cancellationToken = default);
    Task<TransferListResultDto> GetTransferDetail(string card_code,GetPOIAuthKeyRequestDto getPOIAutKeyRequestDto, CancellationToken cancellationToken);
}
