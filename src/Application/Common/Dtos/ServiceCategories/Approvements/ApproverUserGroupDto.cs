using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;

public class ApproverUserGroupDto
{
    public int ServiceCategoryApprovmentId { get; set; }
    public int UserGroupId { get; set; }
}