using System.Diagnostics;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.HttpClients.Handlers;

public class HttpClientLoggingHandler : DelegatingHandler
{
    private readonly ILogger<IVeriSoftHttpClient> _logger;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public HttpClientLoggingHandler(ILogger<IVeriSoftHttpClient> logger)
    {
        _logger = logger ?? throw new ArgumentNullException();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Outgoing request {@request}", request);
        _logger.LogInformation("Outgoing request body : {@body}", request.Content is not null ? await request.Content.ReadAsStringAsync() : default);
        var timer = new Stopwatch();
        timer.Restart();
        var result = await base.SendAsync(request, cancellationToken);
        _logger.LogInformation("Incoming response {@response} in {@timer} ms", result, timer.ElapsedMilliseconds);
        _logger.LogInformation("Incoming response body : {@body}", result.Content is not null ? await result.Content.ReadAsStringAsync() : default);
        return result;
    }
}
