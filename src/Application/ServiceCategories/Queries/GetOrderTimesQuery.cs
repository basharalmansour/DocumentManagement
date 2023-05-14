using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetOrderTimesQuery : IRequest<OrderTimesDto>
{
    public int ServiceCategoryId { get; set; }
}
public class GetOrderTimesQueryHandler : BaseQueryHandler, IRequestHandler<GetOrderTimesQuery, OrderTimesDto>
{
    public GetOrderTimesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<OrderTimesDto> Handle(GetOrderTimesQuery request, CancellationToken cancellationToken)
    {
        var serviceCategory = _applicationDbContext.ServiceCategories.FirstOrDefault(x => x.Id == request.ServiceCategoryId).ServiceCategoryDetails;
        if (serviceCategory == null)
            throw new Exception("Service Category was NOT found");

        OrderTimesDto result = new OrderTimesDto();

        if (serviceCategory.MinOrderDurationUnit == TimeUnit.Hours)
            result.StartTime = DateTime.Now.AddHours(serviceCategory.MinOrderDuration);
        else if (serviceCategory.MinOrderDurationUnit == TimeUnit.Days)
            result.StartTime = DateTime.Now.AddDays(serviceCategory.MinOrderDuration);
        else if(serviceCategory.MinOrderDurationUnit == TimeUnit.Months)
            result.StartTime = DateTime.Now.AddMonths(serviceCategory.MinOrderDuration);
        else if(serviceCategory.MinOrderDurationUnit == TimeUnit.Weeks)
            result.StartTime = DateTime.Now.AddDays(serviceCategory.MinOrderDuration*7);
        else if (serviceCategory.MinOrderDurationUnit == TimeUnit.Years)
            result.StartTime = DateTime.Now.AddYears(serviceCategory.MinOrderDuration);

        if (serviceCategory.MaxOrderDurationUnit == TimeUnit.Hours)
            result.EndTime = DateTime.Now.AddHours(serviceCategory.MaxOrderDuration);
        else if (serviceCategory.MaxOrderDurationUnit == TimeUnit.Days)
            result.EndTime = DateTime.Now.AddDays(serviceCategory.MaxOrderDuration);
        else if (serviceCategory.MaxOrderDurationUnit == TimeUnit.Months)
            result.EndTime = DateTime.Now.AddMonths(serviceCategory.MaxOrderDuration);
        else if (serviceCategory.MaxOrderDurationUnit == TimeUnit.Weeks)
            result.EndTime = DateTime.Now.AddDays(serviceCategory.MaxOrderDuration * 7);
        else if (serviceCategory.MaxOrderDurationUnit == TimeUnit.Years)
            result.EndTime = DateTime.Now.AddYears(serviceCategory.MaxOrderDuration);

        result.MaxServiceDuration = serviceCategory.MaxServiceDuration;
        result.ServiceDurationUnit = serviceCategory.ServiceDurationUnit;
        return result;
    }
}