using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CondoLoginResultDto
{
    public string access_token { get; set; }
    public string refresh_token { get; set; }
    public string site_id { get; set; }
    public bool is_site_admin { get; set; }
    public bool isMainSite { get; set; }
    public string fileStorage { get; set; }
    public object message { get; set; }
    public string user_id { get; set; }
    public List<string> user_roles { get; set; }
    public bool isKvkkPermissionAccepted { get; set; }
    public bool isAgreementTextAccepted { get; set; }
    public object electronicMessagePermission { get; set; }
    public bool is_supervisor { get; set; }
    public bool is_forceChangePassword { get; set; }
    public bool is_shownCargo { get; set; }
}
