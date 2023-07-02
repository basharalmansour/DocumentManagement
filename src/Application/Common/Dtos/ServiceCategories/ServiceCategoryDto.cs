using CleanArchitecture.Application.Common.Helpers;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;
public class ServiceCategoryDto : BasicServiceCategoryDto
{
    public LanguageString Description { get; set; }
    public int? ParentServiceCategoryId { get; set; }
    public ServiceCategoryDetailsDto ServiceCategoryDetails { get; set; }
}
