using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;

public class ServiceCategoryApprovmentDto
{
    public bool IsParallel { get; set; }
    public List<ApproverDepartmentDto> ApproverDepartments { get; set; }
    public List<ApproverPersonnelDto> ApproverPersonnels { get; set; }
    public List<ApproverUserGroupDto> ApproverUserGroups { get; set; }
}