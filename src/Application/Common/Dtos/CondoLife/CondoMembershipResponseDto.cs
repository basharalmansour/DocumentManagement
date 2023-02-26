using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Enums.CondoLifeEnums;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CondoMembershipResponseDto
{
    public int? id { get; set; }
    public CondoRecordStatus Status { get; set; }
    public int ProgramId { get; set; }
    public int? parentId { get; set; }
    public List<CondoLocalizedStringDto> title { get; set; }
    public List<CondoLocalizedStringDto> Description { get; set; }
    public string integrationMembershipId { get; set; }
    public string memberShipUniqueId { get; set; }
    public string Phone { get; set; }
    public DateTime startDateTime { get; set; }
    public DateTime? endDateTime { get; set; }
    public bool IsQuota { get; set; }
    public int? QuotaCount { get; set; }
    public bool IsSale { get; set; }
    public bool IsShowMobile { get; set; }
    public int Rank { get; set; }
    public string siteId { get; set; }

  

}
