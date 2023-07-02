using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Forms.Commands;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Commands;
public class EditPresenceGroupCommand : CreatePresenceGroupCommand, IRequest<int>
{
    public int Id { get; set; }
}
public class EditPresenceGroupCommandHandler : BaseCommandHandler, IRequestHandler<EditPresenceGroupCommand, int>
{

    public EditPresenceGroupCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {

    }
    public async Task<int> Handle(EditPresenceGroupCommand request, CancellationToken cancellationToken)
    {
        var precenceGroup = _applicationDbContext.PresenceGroups
            .Include(x=>x.PresenceGroupUnits)
            .Include(x=>x.PresenceGroupAreas)
            .Include(x=>x.PresenceGroupZones)
            .Include(x=>x.PresenceGroupCompanies)
            .Include(x=>x.PresenceGroupBlocks)
            .Include(x=>x.PresenceGroupBrands)
            .Include(x=>x.PresenceGroupSites)
            .FirstOrDefault(x => x.Id == request.Id);
        
        if (precenceGroup == null)
            throw new Exception("Presence Group was NOT found");

        precenceGroup.DeleteByEdit();
        var newPrecenceGroup = _mapper.Map<PresenceGroup>((CreatePresenceGroupCommand)request);
        newPrecenceGroup.UniqueCode = precenceGroup.UniqueCode;
        _applicationDbContext.PresenceGroups.Add(newPrecenceGroup);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return newPrecenceGroup.Id;
    }
}