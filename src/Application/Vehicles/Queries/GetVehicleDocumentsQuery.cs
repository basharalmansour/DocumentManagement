using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Documents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vehicles.Queries;
public  class GetVehicleDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public int VehicleId { get; set; }
}

public class GetVehicleDocumentsQueryHandler : BaseQueryHandler, IRequestHandler<GetVehicleDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    public GetVehicleDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(GetVehicleDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents=await _applicationDbContext.VehiclesDocuments
            .Include(x=>x.DocumentTemplate)
            .Where(x => x.VehicleId == request.VehicleId)
            .Select(x => x.DocumentTemplate)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}
