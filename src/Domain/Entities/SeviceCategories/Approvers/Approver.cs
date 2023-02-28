using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
public class Approver
{
    [Key]
    public int Id { get; set; }
    public bool IsParallel { get; set; }
}
