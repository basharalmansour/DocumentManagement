//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using CleanArchitecture.Application.Common.Dtos.DocumentTemplate;
//using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
//using CleanArchitecture.Application.Common.Interfaces;
//using CleanArchitecture.Domain.Entities.Documents;
//using CleanArchitecture.Domain.Entities.SeviceCategories;
//using MediatR;

//namespace CleanArchitecture.Application.PresenceGroups.Queries;
//public class PresenceCategoriesQuery : IRequest<List<GetServiceCategoryDto>>
//{
//    public int Id { get; set; }
//}
//public class PresenceCategoriesQueryHandler : IRequestHandler<PresenceCategoriesQuery, List<GetServiceCategoryDto>>
//{
//    private readonly IApplicationDbContext _applicationDbContext;
//    private readonly IMapper _mapper;
//    public PresenceCategoriesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
//    {
//        _applicationDbContext = applicationDbContext;
//        _mapper = mapper;
//    }
//    public async Task<List<GetServiceCategoryDto>> Handle(PresenceCategoriesQuery request, CancellationToken cancellationToken)
//    {
//        List<ServiceCategory> result = new List<ServiceCategory>();
//        var categoryIds = _applicationDbContext..Where(x => x.PresenceGroupId == request.Id).Select(x => x.DocumentTemplateId).ToList();
//        foreach (int id in documentsIds)
//        {
//            var document = _applicationDbContext.DocumentTemplates.FirstOrDefault(x => x.Id == id);
//            result.Add(document);
//        }
//        var resultDto = _mapper.Map<List<GetDocumentTemplateDto>>(result);
//        return resultDto;
//    }
//}