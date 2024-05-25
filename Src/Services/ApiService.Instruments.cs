
using RichillCapital.TraderStudio.Web.Contracts;
using RichillCapital.TraderStudio.Web.Contracts.Instruments;

namespace RichillCapital.TraderStudio.Web.Services;

internal sealed partial class ApiService : IApiService
{
    public async Task<PagedResponse<InstrumentResponse>> ListInstrumentsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<PagedResponse<InstrumentResponse>>("api/v1/instruments");
        return response!;
    }
}