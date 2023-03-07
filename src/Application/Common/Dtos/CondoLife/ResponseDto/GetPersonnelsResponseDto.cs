using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife.ResponseDto;
public class GetPersonnelsResponseDto
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Guid UserId { get; set; }
    public string SiteWorkUnitName { get; set; }
    public string SiteWorkUnitDescription { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string SiteWorkUnitRoleName { get; set; }
    public string SiteWorkUnitRoleDescription { get; set; }
    public int? SiteWorkUnitId { get; set; }
    public bool? IsMain { get; set; }
    public bool IsBusy { get; set; }
}
