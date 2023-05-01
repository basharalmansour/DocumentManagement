using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.CreateDtos;

public class CreateCategoryRoleDto
{
    public Role Role { get; set; }
    public List<int> ResponsibleDepartments { get; set; }
    public List<int> ResponsiblePersonnels { get; set; }
    public List<int> ResponsibleUserGroups { get; set; }
}