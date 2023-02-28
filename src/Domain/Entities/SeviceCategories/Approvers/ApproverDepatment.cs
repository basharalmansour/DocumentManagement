using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class ApproverDepatment
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Approver")]
    public int ApproverId { get; set; }
    public Approver Approver { get; set; }
    public int DepatmentId { get; set; }
}
