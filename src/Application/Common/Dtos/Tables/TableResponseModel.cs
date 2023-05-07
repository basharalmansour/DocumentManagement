using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Tables;

public class TableResponseModel<T>
{
    public List<T> Data { get; set; }
    public int PageCount /*=> Math.Round(TotalRowCount / PageSize)*/; //12
    public int PageNumber { get; set; }//3
    public int PageSize { get; set; }//25
    public int TotalRowCount { get; set; }

    public TableResponseModel(List<T> data)
    {
        Data = data;
    }
}
