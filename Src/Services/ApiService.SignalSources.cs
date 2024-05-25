using RichillCapital.TraderStudio.Web.Contracts;
using RichillCapital.TraderStudio.Web.Contracts.SignalSources;

namespace RichillCapital.TraderStudio.Web.Services;

internal sealed partial class ApiService(
    HttpClient _httpClient) :
    IApiService
{
    public Task CreateSignalSourceAsync(string id, string name, string description, CancellationToken cancellationToken = default)
    {
        var signalSource = new
        {
            Id = id,
            Name = name,
            Description = description
        };

        return _httpClient.PostAsJsonAsync("api/v1/signal-sources", signalSource);
    }

    public async Task<SignalSourceDetailsResponse> GetSignalSourceByIdAsync(
        string signalSourceId,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<SignalSourceDetailsResponse>($"api/v1/signal-sources/{signalSourceId}");

        return response!;
    }

    public async Task<PagedResponse<SignalSourceResponse>> ListSignalSourcesAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<PagedResponse<SignalSourceResponse>>("api/v1/signal-sources");
        return response!;
    }
}
