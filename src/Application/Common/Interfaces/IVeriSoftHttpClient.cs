using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.VeriSoft;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Parameter.ResponseDtos;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Transaction.ResponseDtos;
using CleanArchitecture.Domain.Enums.VeriSoftEnums;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IVeriSoftHttpClient
{
    Task<CheckCustomerResultDto> CheckCustomerAsync(string cardNo, string mobile, CancellationToken cancellationToken = default);
    Task<GetCustomerInfoResultDto> GetCustomerInfoAsync(string customerId, CancellationToken cancellationToken = default);
    Task<List<GetCustomerCreditsResultDto>> GetCustomerCreditsAsync(string customerId, CancellationToken cancellationToken = default);
    Task<UpdateCustomerInfoResultDto> UpdateCustomerInfoAsync(UpdateCustomerInfoRequestDto updateCustomerInfoRequestDto, CancellationToken cancellationToken = default);
    Task<GetCustomerInfoResultDto> CreateCustomerAsync(VerisoftCreateCustomerRequestDto createCustomerRequestDto, CancellationToken cancellationToken = default);
    Task<RenewalCustomerResultDto> RenewalCustomerAsync(RenewalCustomerRequestDto renewalCustomerRequestDto, CancellationToken cancellationToken = default);
    Task<GenerateQRResultDto> GenerateQRAsync(string cardNo, CancellationToken cancellationToken = default);
    Task<List<GetTransactionsResultDto>> GetTransactionsAsync(string cardNp,DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<List<GetCardPropertyGroupsResultDto>> GetCardPropertyGroupsAsync(CancellationToken cancellationToken = default);
    Task<List<GetProductPriceResultDto>> GetProductPricesAsync(string customerId, string cardPropertyGroupId, CancellationToken cancellationToken = default);
    Task<GetProductPriceResultDto> GetProductPriceAsync(string customerId, string cardPropertyGroupId, string cardPropertyGroupBankId, string countryId, CancellationToken cancellationToken = default);
    Task<List<GetCardStatusListResultDto>> GetCardStatusListAsync(CancellationToken cancellationToken = default);
    Task<List<GetCountriesResultDto>> GetCountriesListAsync(CancellationToken cancellationToken = default);
    Task<List<GetCitiesResultDto>> GetCitiesAsync(int countryId,CancellationToken cancellationToken = default);
    Task<List<GetCountiesResultDto>> GetCountiesAsync(int cityId, CancellationToken cancellationToken = default);
    Task<List<GetCardPropertyGroupsDetailResultDto>> GetCardPropertyGroupDetailsAsync(int cardId,CancellationToken cancellationToken = default);
    Task<CheckCustomerByResultDto> CheckCustomerBy(string mobileNo, string email, string identityNumber, CancellationToken cancellationToken = default);
}
