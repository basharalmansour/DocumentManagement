using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Personnels;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Presences.PresencesDocumentTemplates.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Venders.Queries;
public class GetVenderPersonnelsQuery : TableRequestModel, IRequest<TableResponseModel<GetPersonnelDetailsDto>>
{
    public int VenderId { get; set; }
}
public class GetVenderPersonnelsHandler : BaseQueryHandler, IRequestHandler<GetVenderPersonnelsQuery, TableResponseModel<GetPersonnelDetailsDto>>
{
    public GetVenderPersonnelsHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<GetPersonnelDetailsDto>> Handle(GetVenderPersonnelsQuery request, CancellationToken cancellationToken)
    {
        var personnels = _applicationDbContext.VenderPersonnels
            .Where(x => x.VenderId == request.VenderId);
        var selectedPersonnels = await personnels
            .Select(x => new GetPersonnelDetailsDto { PersonnelId = x.PersonnelId })
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        return new TableResponseModel<GetPersonnelDetailsDto>(selectedPersonnels, request.PageNumber, request.PageSize, personnels.Count());
    }
}