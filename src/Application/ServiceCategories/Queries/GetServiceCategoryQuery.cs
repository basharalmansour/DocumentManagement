using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.Forms;
using CleanArchitecture.Application.Common.Dtos.ServiceCategories;
using CleanArchitecture.Application.Common.Dtos.Tables;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Enums;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ServiceCategories.Queries;
public class GetServiceCategoryQuery : TableRequestModel, IRequest<TableResponseModel<BasicServiceCategoryDto>>
{
    public string SearchText { get; set; }
    public bool GetOnlyProducts { get; set; }
    public PresencesType? PresencesType { get; set; }
    public int? PresenceIntegerId { get; set;}
    public Guid? PrsenceGuidId { get; set;}
}
public class GetServiceCategoryHandler : BaseQueryHandler, IRequestHandler<GetServiceCategoryQuery, TableResponseModel<BasicServiceCategoryDto>>
{

    public GetServiceCategoryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
    {
    }
    public async Task<TableResponseModel<BasicServiceCategoryDto>> Handle(GetServiceCategoryQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<ServiceCategory>();
        predicate = predicate.And(x=> !x.IsDeleted);
        if (!string.IsNullOrEmpty(request.SearchText))
            predicate = predicate.And(x => x.Name.ToLower().Contains(request.SearchText));
        if (request.GetOnlyProducts)
        {
            predicate = predicate.And(x => !x.IsMainCategory);
        }

        var categoriesInstall = _applicationDbContext.ServiceCategories
            .Include(x => x.SubServiceCategories.Where(x => x.IsDeleted==false))
            .Where(x=> true);
        
        if (request.PresencesType != null && (request.PresenceIntegerId != null || request.PrsenceGuidId != null))
        {
            switch (request.PresencesType)
            {
                case PresencesType.Area:
                    categoriesInstall = categoriesInstall.Include(x => x.ServiceCategoryDetails.ServiceCategoryAreas);
                    predicate = predicate.And(x => x.ServiceCategoryDetails.ServiceCategoryAreas.Any(x => x.AreaId == request.PresenceIntegerId));
                    break;

                case PresencesType.Block:
                    categoriesInstall = categoriesInstall.Include(x => x.ServiceCategoryDetails.ServiceCategoryBlocks);
                    predicate = predicate.And(x => x.ServiceCategoryDetails.ServiceCategoryBlocks.Any(x => x.BlockId == request.PrsenceGuidId));
                    break;

                case PresencesType.Brand:
                    categoriesInstall = categoriesInstall.Include(x => x.ServiceCategoryDetails.ServiceCategoryBrands);
                    predicate = predicate.And(x => x.ServiceCategoryDetails.ServiceCategoryBrands.Any(x => x.BrandId == request.PresenceIntegerId));
                    break;

                case PresencesType.Company:
                    categoriesInstall = categoriesInstall.Include(x => x.ServiceCategoryDetails.ServiceCategoryCompanies);
                    predicate = predicate.And(x => x.ServiceCategoryDetails.ServiceCategoryCompanies.Any(x => x.CompanyId == request.PresenceIntegerId));
                    break;

                case PresencesType.Site:
                    categoriesInstall = categoriesInstall.Include(x => x.ServiceCategoryDetails.ServiceCategorySites);
                    predicate = predicate.And(x => x.ServiceCategoryDetails.ServiceCategorySites.Any(x => x.SiteId == request.PrsenceGuidId));
                    break;

                case PresencesType.Unit:
                    categoriesInstall = categoriesInstall.Include(x => x.ServiceCategoryDetails.ServiceCategoryUnits);
                    predicate = predicate.And(x => x.ServiceCategoryDetails.ServiceCategoryUnits.Any(x => x.UnitId == request.PresenceIntegerId));
                    break;

                case PresencesType.Zone:
                    categoriesInstall = categoriesInstall.Include(x => x.ServiceCategoryDetails.ServiceCategoryZones);
                    predicate = predicate.And(x => x.ServiceCategoryDetails.ServiceCategoryZones.Any(x => x.ZoneId == request.PrsenceGuidId));
                    break;

                case PresencesType.PresenceGroup:
                    categoriesInstall = categoriesInstall.Include(x => x.ServiceCategoryDetails.ServiceCategoryPresenceGroups);
                    predicate = predicate.And(x => x.ServiceCategoryDetails.ServiceCategoryPresenceGroups.Any(x => x.PresenceGroupId == request.PresenceIntegerId));
                    break;

                default: break;
            }
        }

        var categories = categoriesInstall
            .Where(predicate)
            .Include(z=>z.SubServiceCategories);

        var selectedCategories=await categories
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();
        var categoriesDto = _mapper.Map<List<BasicServiceCategoryDto>>(selectedCategories);
        return new TableResponseModel<BasicServiceCategoryDto>(categoriesDto, request.PageNumber, request.PageSize, categories.Count());
    }
}
