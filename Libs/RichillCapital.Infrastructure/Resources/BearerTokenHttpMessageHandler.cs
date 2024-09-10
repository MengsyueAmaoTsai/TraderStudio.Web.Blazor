using System.Net.Http.Headers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace RichillCapital.Infrastructure.Resources;

internal sealed class BearerTokenHttpMessageHandler(
    ILogger<BearerTokenHttpMessageHandler> _logger,
    IHttpContextAccessor _httpContextAccessor) :
    DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var context = _httpContextAccessor.HttpContext;

        if (context is not null)
        {
            var accessToken = await context.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var identityToken = await context.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            var refreshToken = await context.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            var expiresTimeUtc = await context.GetTokenAsync("expires_at");

            if (request.Headers.Authorization is null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}