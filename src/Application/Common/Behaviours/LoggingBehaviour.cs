﻿using CleanArchitecture.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService, IIdentityService identityService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
        _identityService = identityService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId ?? string.Empty;
 
 

        _logger.LogInformation("CleanArchitecture Request: {Name} {@UserId} {@Request}",
            requestName, userId, request);
    }
}
