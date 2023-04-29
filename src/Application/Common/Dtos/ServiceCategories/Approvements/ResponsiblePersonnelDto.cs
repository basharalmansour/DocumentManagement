using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;

public class ResponsiblePersonnelDto
{
    public int ServiceCategoryRoleId { get; set; }
    public int PersonnelId { get; set; }
}