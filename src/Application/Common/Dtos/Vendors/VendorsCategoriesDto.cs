using CleanArchitecture.Domain.Entities.Vendors;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Common.Dtos.Vendors;

public class VendorsCategoriesDto
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public int VendorCategoryId { get; set; }
}