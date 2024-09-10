using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Infrastructure.Resources;

internal static class HttpContextExtensions
{
    internal static async Task<Result<(
        string AccessToken,
        string IdentityToken,
        string RefreshToken,
        string ExpiresTimeUtc)>> GetTokensAsync(this HttpContext context)
    {
        try
        {
            var accessToken = await context.GetTokenAsync(OpenIdConnectParameterNames.AccessToken) ?? string.Empty;
            var identityToken = await context.GetTokenAsync(OpenIdConnectParameterNames.IdToken) ?? string.Empty;
            var refreshToken = await context.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken) ?? string.Empty;
            var expiresTimeUtc = await context.GetTokenAsync("expires_at") ?? string.Empty;

            return Result<(
                string AccessToken,
                string IdentityToken,
                string RefreshToken,
                string ExpiresTimeUtc)>.With((accessToken, identityToken, refreshToken, expiresTimeUtc));
        }
        catch (Exception ex)
        {
            return Result<(
                string AccessToken,
                string IdentityToken,
                string RefreshToken,
                string ExpiresTimeUtc)>.Failure(Error.Unexpected(ex.Message));
        }
    }
}