using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.PresenceGroups;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Domain.Entities.Vendors;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Presences.PresenceGroups.Queries;

public class GetPresencesGroupsQuery : TableRequestModel, IRequest<TableResponseModel<BasicPresenceGroupDto>>
{
    public string SearchText { get; set; }
}
public class GetPresencesGroupsQueryHandler : BaseQueryHandler, IRequestHandler<GetPresencesGroupsQuery, TableResponseModel<BasicPresenceGroupDto>>
{

    public GetPresencesGroupsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {

    }
    public async Task<TableResponseModel<BasicPresenceGroupDto>> Handle(GetPresencesGroupsQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<PresenceGroup>();
        predicate = predicate.And(x => x.IsDeleted == false);
        if (!string.IsNullOrEmpty(request.SearchText))
            predicate = predicate.And(x => x.Name.ToLower().Contains(request.SearchText.ToLower()));
        var presenceGroups = _applicationDbContext.PresenceGroups
            .Where(predicate);
        var selectedPresenceGroups = await presenceGroups
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var presenceGroupsDto = _mapper.Map<List<BasicPresenceGroupDto>>(selectedPresenceGroups);
        return new TableResponseModel<BasicPresenceGroupDto>(presenceGroupsDto, request.PageNumber, request.PageSize, presenceGroups.Count());
    }
}
