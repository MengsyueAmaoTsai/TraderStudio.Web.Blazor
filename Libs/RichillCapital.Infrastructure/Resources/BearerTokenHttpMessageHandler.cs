using System.Net.Http.Headers;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RichillCapital.Infrastructure.Resources;

internal sealed class BearerTokenHttpMessageHandler(
    ILogger<BearerTokenHttpMessageHandler> _logger,
    IHttpContextAccessor _httpContextAccessor) :
    DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var context = _httpContextAccessor.HttpContext;

        if (context is null)
        {
            return await base.SendAsync(request, cancellationToken);
        }

        var tokensResult = await context.GetTokensAsync();

        if (tokensResult.IsFailure)
        {
            _logger.LogError("Failed to get tokens from HttpContext. {error}", tokensResult.Error);

            return await base.SendAsync(request, cancellationToken);
        }

        var tokens = tokensResult.Value;

        _logger.LogInformation("Setting Bearer token {accessToken} for request.", tokens.AccessToken);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

        return await base.SendAsync(request, cancellationToken);
    }
}