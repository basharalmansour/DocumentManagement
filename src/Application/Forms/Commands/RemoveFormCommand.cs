using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static StackExchange.Redis.Role;

namespace CleanArchitecture.Application.Forms.Commands;
public class RemoveFormCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class RemoveFormCommandHandler : BaseCommandHandler,  IRequestHandler<RemoveFormCommand, bool>
{

    public RemoveFormCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(RemoveFormCommand request, CancellationToken cancellationToken)
    {
        var deletedForm = _applicationDbContext.Forms.FirstOrDefault(x => x.Id == request.Id);
        if (request == null)
            await NullHandleProcesser.ExeptionsThrow("Form");
        deletedForm.IsDeleted = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}