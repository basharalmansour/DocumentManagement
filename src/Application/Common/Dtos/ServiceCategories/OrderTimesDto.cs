using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Dtos.ServiceCategories;

public class OrderTimesDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int MaxServiceDuration { get; set; }
    public TimeUnit ServiceDurationUnit { get; set; }
}