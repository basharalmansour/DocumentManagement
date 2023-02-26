using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Report;

public class ReportEntry
{
    public string Name { get; set; }
    public List<ReportSerie> Series { get; set; }
    public ReportEntry()
    {
        this.Series = new List<ReportSerie>();
    }
}
