using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ServiceCategories.Queries;
using MediatR;

namespace CleanArchitecture.Application.ServiceCategories.Commands;
public class RemoveServiceCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class RemoveServiceCategoryCommandHandler : BaseCommandQueryHandler, IRequestHandler<RemoveServiceCategoryCommand, bool>
{
    public RemoveServiceCategoryCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(mapper, applicationDbContext)
    {
    }
    public async Task<bool> Handle(RemoveServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var deletedCategory = _applicationDbContext.ServiceCategories.FirstOrDefault(x => x.Id == request.Id);
        deletedCategory.IsDeleted = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
