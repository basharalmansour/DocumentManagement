using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Domain.Entities.UserGroups;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class ApproverUserGroup
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Approver")]
    public int ApproverId { get; set; }
    public Approver Approver { get; set; }
    [ForeignKey("UserGroup")]
    public int UserGroupId { get; set; }
    public UserGroup UserGroup  { get; set; }
}
