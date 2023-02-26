using CleanArchitecture.Domain.Enums.CondoLifeEnums;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class NotificationRequestDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string TitleEn { get; set; }
    public string Description { get; set; }
    public string DescriptionEn { get; set; }
    public object ObjectDetail { get; set; }
    public string ImageUrl { get; set; }
    public List<string> UserIds { get; set; }
    public string ObjectTypeOf { get; set; }
    public string Environment { get; set; }
    public UserType UserType { get; set; }
    public bool IsHighPriority { get; set; }
    public Guid SiteId { get; set; }
}