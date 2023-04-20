using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;

public class CreateCategoryRoleDto
{
    public Role Role { get; set; }
    public List<int> ApproverDepartments { get; set; }
    public List<int> ApproverPersonnels { get; set; }
    public List<int> ApproverUserGroups { get; set; }
    public int ServiceCategoryId { get; set; }
}