using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Orders.Queries;
public class GetOrderAvailableTimesQuery : IRequest<OrderAvailableTimesDto>
{
    public int ServiceCategoryId { get; set; }
}
public class GetOrderAvailableTimesQueryHandler : BaseQueryHandler, IRequestHandler<GetOrderAvailableTimesQuery, OrderAvailableTimesDto>
{
    public GetOrderAvailableTimesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<OrderAvailableTimesDto> Handle(GetOrderAvailableTimesQuery request, CancellationToken cancellationToken)
    {
        var serviceCategory = _applicationDbContext.ServiceCategories.FirstOrDefault(x => x.Id == request.ServiceCategoryId).ServiceCategoryDetails;
        if (serviceCategory == null)
            throw new Exception("Service Category was NOT found");

        OrderAvailableTimesDto result = new OrderAvailableTimesDto();

        result.StartTime = DateTime.Now.AddMinutes(TimeUnitsConverter.ConvertToMinutes(serviceCategory.MinOrderDuration, serviceCategory.MinOrderDurationUnit));
        result.EndTime = DateTime.Now.AddMinutes(TimeUnitsConverter.ConvertToMinutes(serviceCategory.MaxOrderDuration, serviceCategory.MaxOrderDurationUnit));

        result.MaxServiceDuration = serviceCategory.MaxServiceDuration;
        result.ServiceDurationUnit = serviceCategory.ServiceDurationUnit;
        return result;
    }
}