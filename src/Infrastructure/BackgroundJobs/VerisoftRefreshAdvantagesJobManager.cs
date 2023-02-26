
using System.Diagnostics;
using AutoMapper;
using CleanArchitecture.Application.Common.Dtos.CondoLife;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Parameter.ResponseDtos;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums.CondoLifeEnums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure.BackgroundJobs;

public class VerisoftRefreshAdvantagesJobManager
{
    private readonly IVeriSoftHttpClient _veriSoftHttpClient;
    private readonly ICondolifeHttpClient _condolifeHttpClient;
    private readonly IMapper _mapper;
    private readonly ILogger<VerisoftRefreshAdvantagesJobManager> _logger;
    private readonly string _tavSiteId;

    public VerisoftRefreshAdvantagesJobManager(IVeriSoftHttpClient veriSoftHttpClient, ICondolifeHttpClient condolifeHttpClient, IMapper mapper, ILogger<VerisoftRefreshAdvantagesJobManager> logger
      , IOptions<AppSettings> options)
    {
        _tavSiteId = options.Value.ClientSettings.CondoLife.TavSiteId;
        _veriSoftHttpClient = veriSoftHttpClient;
        _condolifeHttpClient = condolifeHttpClient;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Process(CancellationToken cancellationToken = default)
    {
        var timer = new Stopwatch();
        timer.Start();
        _logger.LogInformation("VerisoftRefreshAdvantagesJobManager bacground job started");
        var memberships =(await _condolifeHttpClient.GetMembershipsAsync(cancellationToken)).Where(x=>x.parentId == null);
        List<CondoAdvantageDto> condoAdvantages = default;
        List<GetCardPropertyGroupsDetailResultDto> verisoftAdvantages = default;
        List<Task> requestTaskList = new List<Task>();
        foreach (var membership in memberships.Where(x => x.integrationMembershipId != null))
        {

            requestTaskList.Add(Task.Run(async () =>
            {
                timer.Restart();
                condoAdvantages = await _condolifeHttpClient.GetIntegrationAdvantagesAsync(membership.id.GetValueOrDefault(), cancellationToken);
                _logger.LogInformation("Integration advantages fetched from condlife in [{@timer}] ms", timer.ElapsedMilliseconds);
            }));
            requestTaskList.Add(Task.Run(async () =>
            {
                timer.Restart();
                verisoftAdvantages = await _veriSoftHttpClient.GetCardPropertyGroupDetailsAsync(Convert.ToInt32(membership.integrationMembershipId), cancellationToken);
                _logger.LogInformation("Verisoft advantages fetched from verisoft in [{@timer}] ms", timer.ElapsedMilliseconds);
            }));
            Task.WaitAll(requestTaskList.ToArray());
            var upToDateAdvantages = (from vAdvantages in verisoftAdvantages
                                      join cAdvantages in condoAdvantages.Where(x => x.sourceType == CondoAdvantageType.Verisoft)
                                      on vAdvantages.PropertyGroup_ID equals cAdvantages.integrationAdvantageId.Value
                                      into vcAdvantages
                                      from subAdvantages in vcAdvantages.DefaultIfEmpty()
                                      select new CondoAdvantageDto()
                                      {
                                          hasQuota = vAdvantages.Count != 9999,
                                          integrationAdvantageId = vAdvantages.PropertyGroup_ID,
                                          id = subAdvantages?.id,
                                          memberShipId = Convert.ToInt32(membership.id),
                                          name = vAdvantages.Description,
                                          quota = vAdvantages.Count,
                                          sourceType = CondoAdvantageType.Verisoft,
                                          status = 1,
                                          siteId = _tavSiteId
                                      })?.ToList();

            foreach (var upToDateAdvantage in upToDateAdvantages)
            {
                timer.Restart();
                var result = await _condolifeHttpClient.UpsertIntegrationAdvantage(upToDateAdvantage, cancellationToken);
                if (result.id is null)
                    _logger.LogWarning("Condolife advantage upsert process failed! Advanage : {@advantage}", upToDateAdvantage);
                else
                    _logger.LogInformation("Advantages upsert operation finished in [{@timer}] ms", timer.ElapsedMilliseconds);

            }
            foreach (var deletedAdvantageId in condoAdvantages.Where(x=>!upToDateAdvantages.Any(y=>y.id==x.id)).Select(x=>x.id).ToList())
            {
                timer.Restart();
                var result = await _condolifeHttpClient.DeleteAdvantage(deletedAdvantageId.Value, cancellationToken);
                if (result.id is null)
                    _logger.LogWarning("Condolife advantage deleting operation failed! AdvantageId : {@Id}", deletedAdvantageId);
                else
                    _logger.LogInformation("Condolife advantage deleting operation finished in [{@timer}] ms", timer.ElapsedMilliseconds);
            }
        }

    }
}
