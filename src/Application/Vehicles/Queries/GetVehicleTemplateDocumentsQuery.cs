using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Documents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vehicles.Queries;
public  class GetVehicleTemplateDocumentsQuery : IRequest<List<BasicDocumentTemplateDto>>
{
    public int VehicleId { get; set; }
}

public class GetVehicleTemplateDocumentsQueryHandler : BaseQueryHandler, IRequestHandler<GetVehicleTemplateDocumentsQuery, List<BasicDocumentTemplateDto>>
{
    public GetVehicleTemplateDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }
    public async Task<List<BasicDocumentTemplateDto>> Handle(GetVehicleTemplateDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents=await _applicationDbContext.VehiclesDocuments
            .Include(x=>x.DocumentTemplate)
            .Where(x => x.VehicleTemplateId == request.VehicleId)
            .Select(x => x.DocumentTemplate)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(documents);
        return result;
    }
}
