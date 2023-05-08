using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Tables;

public interface ITableRequestModel
{
    int PageNumber { get; set; }
    int PageSize { get; set; }
}
public class TableRequestModel: ITableRequestModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
