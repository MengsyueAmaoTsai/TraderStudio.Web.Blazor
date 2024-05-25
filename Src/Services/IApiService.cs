using RichillCapital.TraderStudio.Web.Contracts;
using RichillCapital.TraderStudio.Web.Contracts.AuditLogs;
using RichillCapital.TraderStudio.Web.Contracts.Instruments;
using RichillCapital.TraderStudio.Web.Contracts.SignalSources;

namespace RichillCapital.TraderStudio.Web.Services;

internal interface IApiService
{
    Task CreateSignalSourceAsync(string id, string name, string description, CancellationToken cancellationToken = default);

    Task<PagedResponse<SignalSourceResponse>> ListSignalSourcesAsync(CancellationToken cancellationToken = default);

    Task<SignalSourceDetailsResponse> GetSignalSourceByIdAsync(
        string signalSourceId,
        CancellationToken cancellationToken = default);

    Task<PagedResponse<AuditLogResponse>> ListAuditLogsAsync(CancellationToken cancellationToken = default);

    Task<PagedResponse<InstrumentResponse>> ListInstrumentsAsync(CancellationToken cancellationToken = default);
}
