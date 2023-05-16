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
        var presenceGroups =  _applicationDbContext.PresenceGroups
             .Where(x => x.IsDeleted == false && x.Name.Contains(request.SearchText, StringComparison.OrdinalIgnoreCase));
        var selectedPresenceGroups = await presenceGroups
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var presenceGroupsDto = _mapper.Map<List<BasicPresenceGroupDto>>(selectedPresenceGroups);
        return new TableResponseModel<BasicPresenceGroupDto>(presenceGroupsDto, request.PageNumber, request.PageSize, presenceGroups.Count());
    }
}
