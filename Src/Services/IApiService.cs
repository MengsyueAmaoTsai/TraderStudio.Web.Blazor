using RichillCapital.TraderStudio.Web.Contracts;

namespace RichillCapital.TraderStudio.Web.Services;

internal interface IApiService
{
    Task<PagedResponse<SignalSourceResponse>> ListSignalSourcesAsync(CancellationToken cancellationToken = default);
    Task<SignalSourceDetailsResponse> GetSignalSourceByIdAsync(
        string signalSourceId,
        CancellationToken cancellationToken = default);
}
