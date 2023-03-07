using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetBrandDetailsResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameEn { get; set; }
    public string Logo { get; set; }
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public int BrandCategoryId { get; set; }
    public string BrandCategory { get; set; }
    public bool IsInside { get; set; }
    public bool IsLoyaltyProgramActive { get; set; }
    public int? MaxLoyaltyPointForEverySingleUsage { get; set; }
    public bool IsActive { get; set; }
}
