using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.Report;

public class ReportResultDto
{
    public ReportResultDto()
    {
        Entries = new List<ReportEntry>();
    }

    public List<ReportEntry> Entries { get; set; }
}
