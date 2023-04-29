using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;

public class ResponsibleDepartmentDto
{
    public int ServiceCategoryRoleId { get; set; }
    public int DepartmentId { get; set; }
}