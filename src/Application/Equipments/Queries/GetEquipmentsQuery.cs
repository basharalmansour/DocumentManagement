using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Equipments;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Equipments.Query;
public  class GetEquipmentsQuery : IRequest<List<EquipmentDto>>
{
}
public class GetEquipmentsHandler : BaseQueryHandler, IRequestHandler<GetEquipmentsQuery, List<EquipmentDto>>
{

    public GetEquipmentsHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<EquipmentDto>> Handle(GetEquipmentsQuery request, CancellationToken cancellationToken)
    {
        var equipment=await _applicationDbContext
            .Equipments
            .Where(x => !x.IsDeleted)
            .ToListAsync();
        
        var result=_mapper.Map<List<EquipmentDto>>(equipment);
        return result;
    }
}