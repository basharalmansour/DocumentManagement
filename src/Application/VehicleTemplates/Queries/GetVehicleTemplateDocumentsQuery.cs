using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Dtos.VehicleTemplates;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.DocumentTemplates;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.VehicleTemplates.Queries;
public  class GetVehicleTemplateDocumentsQuery:TableRequestModel, IRequest<TableResponseModel<BasicDocumentTemplateDto>>
{
    public int VehicleId { get; set; }
}

public class GetVehicleTemplateDocumentsQueryHandler : BaseQueryHandler, IRequestHandler<GetVehicleTemplateDocumentsQuery, TableResponseModel<BasicDocumentTemplateDto>>
{
    public GetVehicleTemplateDocumentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicDocumentTemplateDto>> Handle(GetVehicleTemplateDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = _applicationDbContext.VehicleTemplateDocuments
            .Include(x => x.DocumentTemplate)
            .Where(x => x.VehicleTemplateId == request.VehicleId);
        var selectedDocuments= await documents
            .Select(x => x.DocumentTemplate)
             .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var result = _mapper.Map<List<BasicDocumentTemplateDto>>(selectedDocuments);
        return new TableResponseModel<BasicDocumentTemplateDto>(result, request.PageNumber, request.PageSize, documents.Count());
    }
}
