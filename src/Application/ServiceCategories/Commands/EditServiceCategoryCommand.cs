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
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.ServiceCategories.Commands;
public  class EditServiceCategoryCommand : CreateServiceCategoryCommand, IRequest<int>
{
    public int Id { get; set; }
}
public class EditServiceCategoryCommandHandler : BaseCommandHandler, IRequestHandler<EditServiceCategoryCommand, int>
{

    public EditServiceCategoryCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<int> Handle(EditServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var editedCategory = _applicationDbContext.ServiceCategories.FirstOrDefault(x => x.Id == request.Id);
        if (editedCategory == null)
            throw new Exception("Service Category was NOT found");
        _mapper.Map(request, editedCategory);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return editedCategory.Id;
    }
}
