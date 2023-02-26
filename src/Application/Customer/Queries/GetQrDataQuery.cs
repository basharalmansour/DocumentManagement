using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.QrCode;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.ResponseDtos;
using CleanArchitecture.Application.Common.Interfaces; 
using MediatR;
using QRCoder;

namespace CleanArchitecture.Application.Customer.Queries;

public class GetQrDataQuery : IRequest<QrCodeResponseDto>
{
    public string UserId { get; set; }

    public class GetQrDataQueryHandler : IRequestHandler<GetQrDataQuery, QrCodeResponseDto>
    {
        private readonly IVeriSoftHttpClient _veriSoftHttpClient;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICondolifeHttpClient _condolifeHttpClient;
        private readonly ICurrentUserService _currentUserService;
        public GetQrDataQueryHandler(IVeriSoftHttpClient veriSoftHttpClient, IHttpClientFactory clientFactory, ICondolifeHttpClient condolifeHttpClient, ICurrentUserService currentUserService)
        {
            _veriSoftHttpClient = veriSoftHttpClient;
            _clientFactory = clientFactory;
            _condolifeHttpClient = condolifeHttpClient;
            _currentUserService = currentUserService;
        }

        public async Task<QrCodeResponseDto> Handle(GetQrDataQuery request, CancellationToken cancellationToken)
        {
            var customerInfo = await _condolifeHttpClient.GetUserInfoAsync(request.UserId, cancellationToken);
            GenerateQRResultDto qrData = await _veriSoftHttpClient.GenerateQRAsync(customerInfo.integrationUserId, cancellationToken);
            string qrDataStr = JsonSerializer.Serialize(qrData);
            var qrDataBytes = System.Text.Encoding.UTF8.GetBytes(qrDataStr);
            return new QrCodeResponseDto()
            {
                QrData = Convert.ToBase64String(qrDataBytes)
            };
        }
    }
}
