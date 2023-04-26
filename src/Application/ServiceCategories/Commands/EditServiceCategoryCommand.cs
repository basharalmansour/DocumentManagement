using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.ServiceCategories.Commands;
public  class EditServiceCategoryCommand : CreateServiceCategoryCommand, IRequest<bool>
{
    public int Id { get; set; }
}
public class EditServiceCategoryCommandHandler : BaseCommandQueryHandler, IRequestHandler<EditServiceCategoryCommand, bool>
{

    public EditServiceCategoryCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<bool> Handle(EditServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var editedCategory = _applicationDbContext.ServiceCategories.FirstOrDefault(x => x.Id == request.Id);
        _mapper.Map(request, editedCategory);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
