﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Enums;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Commands;
public class EditPresenceGroupCommand : CreatePresenceGroupCommand, IRequest<int>
{
    public int Id { get; set; }
}
public class EditPresenceGroupCommandHandler : BaseCommandHandler, IRequestHandler<EditPresenceGroupCommand, int>
{

    public EditPresenceGroupCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, IPublishEndpoint publishEndpoint) : base(applicationDbContext, mapper, publishEndpoint)
    {

    }
    public async Task<int> Handle(EditPresenceGroupCommand request, CancellationToken cancellationToken)
    {
        var editedPrecenceGroup = _applicationDbContext.PresenceGroups.FirstOrDefault(x => x.Id == request.Id);
        if (editedPrecenceGroup == null)
            throw new Exception("PresenceGroup was NOT found");
        editedPrecenceGroup.PresenceGroupAreas.Clear();
        editedPrecenceGroup.PresenceGroupBlocks.Clear();
        editedPrecenceGroup.PresenceGroupBrands.Clear();
        editedPrecenceGroup.PresenceGroupCompanies.Clear();
        editedPrecenceGroup.PresenceGroupSites.Clear();
        editedPrecenceGroup.PresenceGroupSites.Clear();
        editedPrecenceGroup.PresenceGroupUnits.Clear();
        editedPrecenceGroup.PresenceGroupZones.Clear();
        _mapper.Map(request, editedPrecenceGroup);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return editedPrecenceGroup.Id;
    }
}
