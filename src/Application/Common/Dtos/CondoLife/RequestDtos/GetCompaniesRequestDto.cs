using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.RequestDtos;
public class GetCompaniesRequestDto
{
    public Dictionary<CompanyFilter, string> CompanyFilter { get; set; }
    public bool? IsFrontDeskAdded { get; set; }
    public bool IsActive { get; set; }
}
public enum CompanyFilter
{
    [Display(Name = "Firma Adı")]
    CompanyName = 1,
    [Display(Name = "Firma Vergi Numarası")]
    CompanyTaxNo = 2,
    [Display(Name = "Firma Yetkilisi")]
    CompanyResponsibleName = 3
}
