using Microsoft.Extensions.Logging;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Infrastructure.Resources;

public class HttpHandler
{
}

public interface IResourceService
{
}

internal sealed class ResourceService(
    ILogger<ResourceService> _logger,
    HttpClient _httpClient,
    ITokenManager _tokenManager) :
    HttpHandler,
    IResourceService
{
    public async Task<Result> ListSignalSourcesAsync()
    {
        return Result.Success;
    }
}