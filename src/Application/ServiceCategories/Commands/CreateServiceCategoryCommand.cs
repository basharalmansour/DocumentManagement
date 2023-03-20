using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Enums;
using MediatR;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using static StackExchange.Redis.Role;
using CleanArchitecture.Domain.Entities.Documents;

namespace CleanArchitecture.Application.ServiceCategories.Commands;

public class CreateServiceCategoryCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxServiceDuration { get; set; }
    public TimeUnit ServiceDurationUnit { get; set; }
    public int MaxPersonnelCount { get; set; }
    public List<int> PersonnelDocuments { get; set; }
    public int? ParentServiceCategoryId { get; set; } 
    public CreateApprovementDto ServiceCategoryApprovement { get; set; }
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
}
public class CreateServiceCategoryCommandHandler : IRequestHandler<CreateServiceCategoryCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public CreateServiceCategoryCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.ServiceDurationUnit == TimeUnit.Days)
            request.MaxServiceDuration *= 24;
        else if (request.ServiceDurationUnit == TimeUnit.Weeks)
            request.MaxServiceDuration *= 168;
        else if (request.ServiceDurationUnit == TimeUnit.Months)
            request.MaxServiceDuration *= 720;
        else if (request.ServiceDurationUnit == TimeUnit.Years)
            request.MaxServiceDuration *= 8760;
        var serviceCategory = _mapper.Map<ServiceCategory>(request);
        _applicationDbContext.ServiceCategories.Add(serviceCategory);
        
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return serviceCategory.Id;
    } 
}
