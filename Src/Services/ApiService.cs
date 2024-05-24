using RichillCapital.TraderStudio.Web.Contracts;

namespace RichillCapital.TraderStudio.Web.Services;

internal sealed class ApiService(HttpClient _httpClient) : IApiService
{
    public async Task<SignalSourceDetailsResponse> GetSignalSourceByIdAsync(
        string signalSourceId,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<SignalSourceDetailsResponse>($"https://localhost:10000/api/v1/signal-sources/{signalSourceId}");

        return response!;
    }

    public async Task<PagedResponse<SignalSourceResponse>> ListSignalSourcesAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<PagedResponse<SignalSourceResponse>>("https://localhost:10000/api/v1/signal-sources");
        return response!;
    }
}
