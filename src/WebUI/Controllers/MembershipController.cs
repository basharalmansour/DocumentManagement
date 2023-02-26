using CleanArchitecture.Application.Memberships.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
[Authorize]
public class MembershipController : ApiControllerBase
{
    [HttpGet("GetPrice")]
    public async Task<IActionResult> GetPrice(int membershipId)
    {
        var result = await Sender.Send(new GetMembershipPriceQuery()
        {
            MembershipId = membershipId.ToString(),
        });
        return Ok(result);
    }
}
