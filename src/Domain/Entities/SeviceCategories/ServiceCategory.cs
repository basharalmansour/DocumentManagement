using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.SeviceCategories;
public class ServiceCategory : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    [StringLength(StringLengths.VeryLongString)]
    public string Name { get; set; }
    public string Description { get; set; }
    public ServiceCategoryDetails ServiceCategoryDetails { get; set; }
    public bool IsMainCategory { get; set; }

    [ForeignKey(nameof(ParentServiceCategory))]
    public int? ParentServiceCategoryId { get; set; }
    public ServiceCategory ParentServiceCategory { get; set; }
    public List<ServiceCategory> SubServiceCategories { get; set; }

}
