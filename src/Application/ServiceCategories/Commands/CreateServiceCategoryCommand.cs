using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Enums;
using MediatR;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories.CreateDtos;

namespace CleanArchitecture.Application.ServiceCategories.Commands;

public class CreateServiceCategoryCommand : IRequest<int>
{
    public LanguageString Name { get; set; }
    public LanguageString Description { get; set; }
    public int MaxServiceDuration { get; set; }
    public TimeUnit ServiceDurationUnit { get; set; }
    public int MaxPersonnelCount { get; set; }
    public List<int> PersonnelDocuments { get; set; }
    public int? ParentServiceCategoryId { get; set; }
    public bool IsParallelApprovement { get; set; }
    public CreateCategoryRoleDto ServiceCategoryRoles { get; set; }
    public List<int> SpecialRules { get; set; }
    public List<int> Documents { get; set; }
    public List<CreateVehicleCategoryDto> Vehicles { get; set; }
    public List<int> ServiceCategoryAreas { get; set; }
    public List<Guid> ServiceCategoryBlocks { get; set; }
    public List<int> ServiceCategoryBrands { get; set; }
    public List<int> ServiceCategoryCompanies { get; set; }
    public List<Guid> ServiceCategorySites { get; set; }
    public List<int> ServiceCategoryUnits { get; set; }
    public List<Guid> ServiceCategoryZones { get; set; }
    public List<int> ServiceCategoryPresenceGroups { get; set; }
}
public class CreateServiceCategoryCommandHandler : BaseCommandQueryHandler, IRequestHandler<CreateServiceCategoryCommand, int>
{

    public CreateServiceCategoryCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<int> Handle(CreateServiceCategoryCommand request, CancellationToken cancellationToken)
    {
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
