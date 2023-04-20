using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;

public class ServiceCategoryRoleDto
{
    public Role Role { get; set; }
    public List<ApproverDepartmentDto> ApproverDepartments { get; set; }
    public List<ApproverPersonnelDto> ApproverPersonnels { get; set; }
    public List<ApproverUserGroupDto> ApproverUserGroups { get; set; }
}