using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.RequestDtos;
public class GetBrandsRequestDto
{
    public Dictionary<BrandFilter, string> BrandFilter { get; set; }
    public List<int?> BrandType { get; set; }
    public string CompanyName { get; set; }
    public bool? IsFrontDeskAdded { get; set; }
    public bool IsActive { get; set; }
}
public enum BrandFilter
{
    [Display(Name = "Marka Adı")]
    BrandName = 1,
    [Display(Name = "Marka Tipi")]
    BrandType = 2
}