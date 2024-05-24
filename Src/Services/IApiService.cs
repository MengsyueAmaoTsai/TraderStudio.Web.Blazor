using RichillCapital.TraderStudio.Web.Contracts;

namespace RichillCapital.TraderStudio.Web.Services;

internal interface IApiService
{
    Task<PagedResponse<SignalSourceResponse>> ListSignalSourcesAsync(CancellationToken cancellationToken = default);
}
