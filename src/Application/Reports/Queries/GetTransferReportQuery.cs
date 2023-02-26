using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Dtos.Report;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Reports.Queries;

public class GetTransferReportQuery : IRequest<ReportResultDto>
{
    public DateTime StartDate { get; set; }
    public DateTime DateTime { get; set; }
}

public class GetTransferReportResultQueryHandler : IRequestHandler<GetTransferReportQuery, ReportResultDto>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly ICondolifeHttpClient _condolifeHttpClient;

    public GetTransferReportResultQueryHandler(IApplicationDbContext applicationDbContext, ICondolifeHttpClient condolifeHttpClient)
    {
        _applicationDbContext = applicationDbContext;
        _condolifeHttpClient = condolifeHttpClient;
    }

    public async Task<ReportResultDto> Handle(GetTransferReportQuery request, CancellationToken cancellationToken)
    {
        var memberships = await _condolifeHttpClient.GetMembershipsAsync(cancellationToken);
        var titles = memberships.SelectMany(x => x.title).DistinctBy(x=>x.value);
        ReportResultDto result = new ReportResultDto();
        var entry = new ReportEntry()
        {
            Name = "Transfer"
        };
        foreach (var membershipTitle in titles)
        {
            var transferOrderCount = _applicationDbContext.Orders.Count(x => x.OrderDescription.ToLower().Contains(membershipTitle.value));

             entry.Series.Add(new ReportSerie()
             {
                 Name = membershipTitle.value,
                 Value = transferOrderCount
             });
        }
        result.Entries.Add(entry);
        return result;
    }
}
