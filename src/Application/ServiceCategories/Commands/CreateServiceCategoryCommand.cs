using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Enums;
using MediatR;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories.CreateDtos;
using MassTransit;

namespace CleanArchitecture.Application.ServiceCategories.Commands;

public class CreateServiceCategoryCommand : IRequest<int>
{
    public LanguageString Name { get; set; }
    public LanguageString Description { get; set; }
    public bool IsMainCategory { get; set; }
    public CreateServiceCategoryDetailsDto ServiceCategoryDetails { get; set; }
}
public class CreateServiceCategoryCommandHandler : BaseCommandHandler, IRequestHandler<CreateServiceCategoryCommand, int>
{

    public CreateServiceCategoryCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<int> Handle(CreateServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.IsMainCategory)
            request.ServiceCategoryDetails = null;
        var serviceCategory = _mapper.Map<ServiceCategory>(request);
        serviceCategory.UniqueCode= UniqueCode.CreateUniqueCode(8, false, "S");
        _applicationDbContext.ServiceCategories.Add(serviceCategory);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return serviceCategory.Id;
    }

    //private int DurationInHours(int maxServiceDuration, TimeUnit serviceDurationUnit)
    //{
    //    if (serviceDurationUnit == TimeUnit.Days)
    //        maxServiceDuration *= 24;
    //    else if (serviceDurationUnit == TimeUnit.Weeks)
    //        maxServiceDuration *= 168;
    //    else if (serviceDurationUnit == TimeUnit.Months)
    //        maxServiceDuration *= 720;
    //    else if (serviceDurationUnit == TimeUnit.Years)
    //        maxServiceDuration *= 8760;
    //    return maxServiceDuration;
    //}
}
