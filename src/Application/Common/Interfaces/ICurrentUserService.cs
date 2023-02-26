namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string? UserId { get; }
    string JWT { get; }
    string SiteId { get; }
}
