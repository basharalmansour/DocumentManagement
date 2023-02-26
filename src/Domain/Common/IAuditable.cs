using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common;
/// <summary>
/// If you take audit log of entity. You must implement this interface
/// </summary>
public interface IAuditable
{
    [MaxLength(64)]
    public string CreatedBy { get; set; }
    [MaxLength(64)]
    public string ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
