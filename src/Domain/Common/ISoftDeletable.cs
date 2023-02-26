using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common;
/// <summary>
/// If you want the asset to be soft deleted.
/// You need to implement this interface
/// </summary>
public interface ISoftDeletable
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string DeletedBy { get; set; }
}
