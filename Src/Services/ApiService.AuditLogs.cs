using RichillCapital.TraderStudio.Web.Contracts;
using RichillCapital.TraderStudio.Web.Contracts.AuditLogs;

namespace RichillCapital.TraderStudio.Web.Services;

internal sealed partial class ApiService :
    IApiService
{
    public async Task<PagedResponse<AuditLogResponse>> ListAuditLogsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<PagedResponse<AuditLogResponse>>("api/v1/audit-logs");
        return response!;
    }
}