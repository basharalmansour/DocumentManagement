using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.BackgroundJobs;

public class OrderDetailStatusesJobManager
{
    //private readonly IMongoDbRepository<OrderPropertyDetails> _mongoDbRepository;
    //private readonly ILogger<OrderDetailStatusesJobManager> _logger;

    //public OrderDetailStatusesJobManager
    //(
    //    IMongoDbRepository<OrderPropertyDetails> mongoDbRepository,
    //    ILogger<OrderDetailStatusesJobManager> logger
    //)
    //{
    //    _mongoDbRepository = mongoDbRepository;
    //    _logger = logger;
    //}

    public async Task Process(CancellationToken cancellationToken = default)
    {
        //_logger.LogInformation("OrderDetailStatusesJobManager background job started...");

        //var orderPropertyDetails = _mongoDbRepository.Get(x =>
        //    ((OrderDetailDto) x.Detail).Status == TransactionStatus.Planned);

        //foreach (var orderPropertyDetail in orderPropertyDetails)
        //{
        //    var reservationDate = ((OrderDetailDto) orderPropertyDetail.Detail).ReservationDate;

        //    if (reservationDate.GetValueOrDefault() == default) continue;

        //    if (DateTime.Now < reservationDate) continue;
            
        //    ((OrderDetailDto) orderPropertyDetail.Detail).Status = TransactionStatus.Completed;

        //    await _mongoDbRepository.UpdateAsync(orderPropertyDetail.Id, orderPropertyDetail, cancellationToken);
        //}
        
        //_logger.LogInformation("OrderDetailStatusesJobManager background job completed...");
    }
}