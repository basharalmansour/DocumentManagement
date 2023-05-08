using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Tables;

public class TableResponseModel<T>
{
    public List<T> Data { get; set; }
    public int PageCount { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalRowCount { get; }

    public TableResponseModel(List<T> data, int pageNumber, int pageSize, int totalRowCount)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalRowCount = totalRowCount;
        PageCount =(int)Math.Ceiling((double)TotalRowCount / PageSize);
    }
}
