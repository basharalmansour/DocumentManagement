using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories.Approvements;

public class ResponsibleUserGroupDto
{
    public int ServiceCategoryRoleId { get; set; }
    public int UserGroupId { get; set; }
}