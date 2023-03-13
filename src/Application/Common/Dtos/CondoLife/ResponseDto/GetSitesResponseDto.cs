using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetSitesResponseDto
{
    public Guid Id { get; set; }
    public Guid ParentSiteId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string DefaultUnitLogo { get; set; }
    public List<GetSitesResponseDto> SubSites { get; set; }
}
