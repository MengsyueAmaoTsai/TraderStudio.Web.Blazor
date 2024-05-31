using RichillCapital.TraderStudio.Web.Services.Contracts.Accounts;
using RichillCapital.TraderStudio.Web.Services.Contracts.Users;
using RichillCapital.TraderStudio.Web.Src.Services.Contracts;

namespace RichillCapital.TraderStudio.Web.Services;

internal sealed partial class ApiService(
    HttpClient _httpClient) :
    IApiService
{
    public async Task<PagedResponse<UserResponse>> ListUsersAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("api/v1/users", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<PagedResponse<UserResponse>>(cancellationToken: cancellationToken);
        return content!;
    }

    public async Task<PagedResponse<AccountResponse>> ListAccountsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("api/v1/accounts", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<PagedResponse<AccountResponse>>(cancellationToken: cancellationToken);
        return content!;
    }
}
