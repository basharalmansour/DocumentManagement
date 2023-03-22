using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;

public class ApproverPersonnelDto
{
    public int ServiceCategoryApprovmentId { get; set; }
    public int PersonnelId { get; set; }
}