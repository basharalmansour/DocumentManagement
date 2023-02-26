using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.WebUI.Filters;

public class CondoLifeUserCheckFilterAttribute : ActionFilterAttribute
{
    private readonly string _updateClientKey;
    private readonly ILogger<VerisoftUserCheckFilterAttribute> _logger;
    public CondoLifeUserCheckFilterAttribute(IOptions<AppSettings> options, ILogger<VerisoftUserCheckFilterAttribute> logger)
    {
        _updateClientKey = options.Value.ClientSettings.CondoLife.ClientKey;
        _logger = logger;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var clientKey = context.HttpContext.Request.Headers["Client-Key"].ToString() ?? throw new UnauthorizedAccessException();
        if (_updateClientKey != clientKey)
        {
            _logger.LogWarning("Verisoft Unauthorized request! Client-Key : {@clientKey}", clientKey);
            throw new UnauthorizedAccessException();
        }

        base.OnActionExecuting(context);
    }
}
