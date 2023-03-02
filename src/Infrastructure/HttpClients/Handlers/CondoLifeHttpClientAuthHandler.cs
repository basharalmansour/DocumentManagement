using System.Net;
using System.Text.Json;
using CleanArchitecture.Application.Common.Dtos.CondoLife;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.HttpClients.CondoLife;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Infrastructure.HttpClients.Handlers;

public class CondoLifeHttpClientAuthHandler : DelegatingHandler
{
    private readonly ICurrentUserService _currentUserService;
    private readonly CondoLifeAuthorizationAdapter _condoLifeAuthorizationAdapter;

    public CondoLifeHttpClientAuthHandler
    (
        ICurrentUserService currentUserService,
        CondoLifeAuthorizationAdapter condoLifeAuthorizationAdapter
    )
    {
        _currentUserService = currentUserService;
        _condoLifeAuthorizationAdapter = condoLifeAuthorizationAdapter;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        bool isAppRequest = false;
        var jwt = _currentUserService.JWT;
        var siteId = _currentUserService.SiteId;
        //if (siteId == null)
        //    siteId = _condoLifeAuthorizationAdapter.GetTavSiteId();
        if (jwt == null)
        {
            isAppRequest = true;
            jwt = "Bearer " + await _condoLifeAuthorizationAdapter.GetAccessToken();
        }
        request.Headers.Clear();
        request.Headers.Add("Authorization", jwt);
        request.Headers.Add("Site-Id", siteId);

        var result = await base.SendAsync(request, cancellationToken);
        try
        {
            result.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            string content;
            CondoErrorResponseDto errorResponseDto;
            switch (result.StatusCode)
            {
                case (HttpStatusCode) StatusCodes.Status404NotFound:
                    content = await result.Content.ReadAsStringAsync(cancellationToken);
                    errorResponseDto = JsonSerializer.Deserialize<CondoErrorResponseDto>(content);
                    throw new NotFoundException(errorResponseDto?.message);

                case (HttpStatusCode) StatusCodes.Status409Conflict:
                    content = await result.Content.ReadAsStringAsync(cancellationToken);
                    errorResponseDto = JsonSerializer.Deserialize<CondoErrorResponseDto>(content);
                    throw new ConflictException(errorResponseDto?.message);

                case (HttpStatusCode) StatusCodes.Status401Unauthorized:
                    if (isAppRequest)
                    {
                        jwt = "Bearer " +await _condoLifeAuthorizationAdapter.GetAccessToken(true);
                        request.Headers.Clear();
                        request.Headers.Add("Authorization", jwt);
                        request.Headers.Add("Site-Id", siteId);
                        await SendAsync(request, cancellationToken);
                    }
                    throw new UnauthorizedAccessException();

                case (HttpStatusCode) StatusCodes.Status400BadRequest:
                    content = await result.Content.ReadAsStringAsync(cancellationToken);
                    errorResponseDto = JsonSerializer.Deserialize<CondoErrorResponseDto>(content);
                    throw new BadRequestException(errorResponseDto?.message);

                default:
                    content = await result.Content.ReadAsStringAsync(cancellationToken);
                    errorResponseDto = JsonSerializer.Deserialize<CondoErrorResponseDto>(content);
                    throw new Exception(errorResponseDto?.message);
            }
        }

        return result;
    }
}