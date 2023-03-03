using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Forms.Commands;
public class RemoveFormCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class RemoveFormCommandHandler : IRequestHandler<RemoveFormCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    public RemoveFormCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public async Task<bool> Handle(RemoveFormCommand request, CancellationToken cancellationToken)
    {
        var deletedForm = _applicationDbContext.Forms.FirstOrDefault(x => x.Id == request.Id);
        deletedForm.IsDeleted = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}