using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Equipments;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Forms.Queries;
using CleanArchitecture.Domain.Entities.Definitions.SpecialRules;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Equipments.Query;
public  class GetEquipmentSpecialRulesQuery : IRequest<EquipmentDto>
{
    public int EquipmentId { get; set; }
}
public class GetEquipmentSpecialRulesHandler : BaseQueryHandler, IRequestHandler<GetEquipmentSpecialRulesQuery, EquipmentDto>
{

    public GetEquipmentSpecialRulesHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }
    public async Task<EquipmentDto> Handle(GetEquipmentSpecialRulesQuery request, CancellationToken cancellationToken)
    {
        var equipment=await _applicationDbContext.Equipments.FirstOrDefaultAsync(x => x.Id == request.EquipmentId);
        if (equipment == null)
            throw new Exception("equipment was NOT found");
        var result=_mapper.Map<EquipmentDto>(equipment);
        return result;
    }
}