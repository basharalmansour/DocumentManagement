using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;

public class CreateApprovementDto
{
    public bool IsParallel { get; set; }
    public List<int> ApproverDepartments { get; set; }
    public List<int> ApproverPersonnels { get; set; }
    public List<int> ApproverUserGroups { get; set; }
}