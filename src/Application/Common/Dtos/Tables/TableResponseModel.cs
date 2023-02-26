using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Tables;

public class TableResponseModel
{
    public object Data { get; set; }
    public int PageCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRowCount { get; set; }
}
