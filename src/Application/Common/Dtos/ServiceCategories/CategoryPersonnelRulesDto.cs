using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;

public class CategoryPersonnelRulesDto
{
    public int ApproverPersonnelId { get; set; }
    public Rule Rule { get; set; }
}