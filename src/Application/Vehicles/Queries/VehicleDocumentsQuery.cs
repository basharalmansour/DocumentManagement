using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Vehicles;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.Documents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Vehicles.Queries;
public  class VehicleDocumentsQuery : IRequest<List<GetDocumentTemplateDto>>
{
    public int VehicleId { get; set; }
}

public class VehicleDocumentsQueryHandler : IRequestHandler<VehicleDocumentsQuery, List<GetDocumentTemplateDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public VehicleDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<List<GetDocumentTemplateDto>> Handle(VehicleDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents=await _applicationDbContext.VehiclesDocuments.Where(x => x.VehicleId == request.VehicleId).Select(x => x.DocumentTemplate).ToListAsync();
        var result = _mapper.Map<List<GetDocumentTemplateDto>>(documents);
        return result;
    }
}
