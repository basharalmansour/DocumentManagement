using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class CategoryPersonnelRules
{
    [ForeignKey("ApproverPersonnel")]
    public int ApproverPersonnelId { get; set; }
    public ApproverPersonnel ApproverPersonnel { get; set; }
    public Rule Rule { get; set; }
}
