using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Commands;
public  class EditServiceCategoryCommand : CreateServiceCategoryCommand, IRequest<int>
{
    public int Id { get; set; }
}
public class EditServiceCategoryCommandHandler : BaseCommandHandler, IRequestHandler<EditServiceCategoryCommand, int>
{

    public EditServiceCategoryCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<int> Handle(EditServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var serviceCategory = _applicationDbContext.ServiceCategories
            .Include(x=>x.SubServiceCategories)
            .FirstOrDefault(x => x.Id == request.Id);
        if (serviceCategory == null)
            throw new Exception("Service Category was NOT found");
        serviceCategory.DeleteByEdit();

        var newServiceCategory = _mapper.Map<ServiceCategory>((CreateServiceCategoryCommand)request);
        newServiceCategory.UniqueCode = serviceCategory.UniqueCode;
        _applicationDbContext.ServiceCategories.Add(newServiceCategory);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        serviceCategory.SubServiceCategories?.ForEach(x => x.ParentServiceCategoryId = newServiceCategory.Id);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return newServiceCategory.Id;
    }
}
