using Hangfire;

namespace CleanArchitecture.Infrastructure.BackgroundJobs;

public static class RecurringJobs
{
    public static void RefreshVerisoftAdvantagesOperation()
    {
        RecurringJob.AddOrUpdate<VerisoftRefreshAdvantagesJobManager>(nameof(VerisoftRefreshAdvantagesJobManager),
            job => job.Process(new CancellationToken()), "0 */5 * * *", TimeZoneInfo.Local);
    }
    
    public static void UpdateOrderDetailStatusesOperation()
    {
        RecurringJob.AddOrUpdate<OrderDetailStatusesJobManager>(nameof(OrderDetailStatusesJobManager),
            job => job.Process(new CancellationToken()), Cron.Daily, TimeZoneInfo.Local);
    }

}
