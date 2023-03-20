using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;

public class ApproverDepartmentDto
{
    public int ServiceCategoryApprovmentId { get; set; }
    public int DepartmentId { get; set; }
}