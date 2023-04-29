using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;

public class ServiceCategoryRoleDto
{
    public Role Role { get; set; }
    public List<ResponsibleDepartmentDto> ResponsibleDepartments { get; set; }
    public List<ResponsiblePersonnelDto> ResponsiblePersonnels { get; set; }
    public List<ResponsibleUserGroupDto> ResponsibleUserGroups { get; set; }
}