using System.Net.Http.Json;

using Microsoft.Extensions.Logging;

using RichillCapital.Infrastructure.Resources.Contracts.SignalSources;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Infrastructure.Resources;

internal sealed class ResourceService(
    ILogger<ResourceService> _logger,
    HttpClient _httpClient,
    ITokenManager _tokenManager) :
    HttpHandler,
    IResourceService
{
    public async Task<Result<IEnumerable<SignalSourceResponse>>> ListSignalSourcesAsync()
    {
        var sources = await _httpClient.GetFromJsonAsync<IEnumerable<SignalSourceResponse>>("api/v1/signal-sources");

        return Result<IEnumerable<SignalSourceResponse>>.With(sources!);
    }
}