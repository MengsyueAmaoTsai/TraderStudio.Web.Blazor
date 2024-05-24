using RichillCapital.TraderStudio.Web.Contracts;

namespace RichillCapital.TraderStudio.Web.Components.Pages.SignalSources;

internal static class HttpClientExtensions
{
    internal static async Task<PagedResponse<SignalSourceResponse>> ListSignalSourcesAsync(this HttpClient httpClient)
    {
        var response = await httpClient.GetFromJsonAsync<PagedResponse<SignalSourceResponse>>("https://localhost:10000/api/v1/signal-sources");

        return response!;
    }
}