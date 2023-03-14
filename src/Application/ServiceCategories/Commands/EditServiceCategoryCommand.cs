using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.ServiceCategories.Commands;
public  class EditServiceCategoryCommand : CreateServiceCategoryCommand, IRequest<bool>
{
    public int Id { get; set; }
}
public class EditServiceCategoryCommandHandler : IRequestHandler<EditServiceCategoryCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public EditServiceCategoryCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(EditServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var editedCategory = _applicationDbContext.ServiceCategories.FirstOrDefault(x => x.Id == request.Id);
        editedCategory.ServiceCategoryAreas.Clear();
        editedCategory.ServiceCategoryBlocks.Clear();
        editedCategory.ServiceCategoryBrands.Clear();
        editedCategory.ServiceCategoryCompanies.Clear();
        editedCategory.ServiceCategorySites.Clear();
        editedCategory.ServiceCategoryUnits.Clear();
        editedCategory.ServiceCategoryZones.Clear();
        editedCategory.SpecialRules.Clear();
        _mapper.Map(request, editedCategory);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
