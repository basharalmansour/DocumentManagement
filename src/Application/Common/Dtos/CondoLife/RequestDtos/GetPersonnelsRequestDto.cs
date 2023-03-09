using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.RequestDtos;
public class GetPersonnelsRequestDto
{
    public EmployeeFilterType FilterType { get; set; }
    public string SearchString { get; set; }
    public int? SiteWorkUnitId { get; set; }
    public int?[] SiteWorkUnitIds { get; set; }
    public List<int> EmployeeIdList { get; set; }
}
public enum EmployeeFilterType
{
    [Display(Name = "Aktif")]
    Active = 1,
    [Display(Name = "Eski Personel")]
    Passive = 2,
    [Display(Name = "Tüm Personel")]
    All = 3
}