using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Domain.Entities.Definitions.Venders;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Venders.Commands;
public class CreateVenderPersonnelCommand : IRequest<bool>
{
    public int VenderId { get; set; }
    public List<int> PersonnelIds { get; set; }
}
public class CreateVenderPersonnelCommandHandler : BaseCommandHandler, IRequestHandler<CreateVenderPersonnelCommand, bool>
{
    public CreateVenderPersonnelCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {
    }
    public async Task<bool> Handle(CreateVenderPersonnelCommand request, CancellationToken cancellationToken)
    {
        var venderPersonnel = _mapper.Map<VenderPersonnel>(request);
        _applicationDbContext.VenderPersonnels.Add(venderPersonnel);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}