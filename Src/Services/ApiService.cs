using Microsoft.AspNetCore.Mvc;

using RichillCapital.TraderStudio.Web.Services.Contracts.Accounts;
using RichillCapital.TraderStudio.Web.Services.Contracts.Executions;
using RichillCapital.TraderStudio.Web.Services.Contracts.Instruments;
using RichillCapital.TraderStudio.Web.Services.Contracts.Orders;
using RichillCapital.TraderStudio.Web.Services.Contracts.Users;
using RichillCapital.TraderStudio.Web.Src.Services.Contracts;

namespace RichillCapital.TraderStudio.Web.Services;

internal sealed partial class ApiService(
    ILogger<ApiService> _logger,
    HttpClient _httpClient) :
    IApiService
{
    public async Task<PagedResponse<UserResponse>> ListUsersAsync(CancellationToken cancellationToken = default) =>
        await SendRequestAsync<PagedResponse<UserResponse>>(
            HttpMethod.Get,
            "api/v1/users");

    public async Task<UserDetailsResponse> GetUserByIdAsync(
        string userId,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"api/v1/users/{userId}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<UserDetailsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    public async Task<PagedResponse<InstrumentResponse>> ListInstrumentsAsync(CancellationToken cancellationToken = default) =>
        await SendRequestAsync<PagedResponse<InstrumentResponse>>(
            HttpMethod.Get,
            "api/v1/instruments");

    public async Task<PagedResponse<AccountResponse>> ListAccountsAsync(CancellationToken cancellationToken = default) =>
        await SendRequestAsync<PagedResponse<AccountResponse>>(
            HttpMethod.Get,
            "api/v1/accounts");

    public async Task<AccountDetailsResponse> GetAccountByIdAsync(
        string accountId,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"api/v1/accounts/{accountId}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<AccountDetailsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    public async Task<PagedResponse<OrderResponse>> ListOrdersAsync(CancellationToken cancellationToken = default) =>
        await SendRequestAsync<PagedResponse<OrderResponse>>(
            HttpMethod.Get,
            "api/v1/orders");

    public async Task<string> CreateOrderAsync(
        CreateOrderRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v1/orders",
            request,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            await HandleErrorAsync(response);

            return string.Empty;
        }

        var result = await response.Content.ReadFromJsonAsync<CreateOrderResponse>(cancellationToken);

        return result!.Id;
    }

    public async Task<PagedResponse<ExecutionResponse>> ListExecutionsAsync(CancellationToken cancellationToken = default) =>
        await SendRequestAsync<PagedResponse<ExecutionResponse>>(
            HttpMethod.Get,
            "api/v1/executions");

    private async Task<TResponse> SendRequestAsync<TResponse>(
        HttpMethod method,
        string path)
    {
        var request = new HttpRequestMessage(method, path);

        return await SendRequestAsync<TResponse>(request);
    }

    private async Task<TResponse> SendRequestAsync<TResponse>(
        HttpRequestMessage request,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            await HandleErrorAsync(response);

            return default!;
        }

        var content = await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);

        _logger.LogInformation(
            "Request to {RequestUri} completed successfully",
            request.RequestUri);

        return content!;
    }

    private async Task HandleErrorAsync(HttpResponseMessage response)
    {
        var problem = await response.Content.ReadFromJsonAsync<ProblemDetails>();

        _logger.LogError(
            "An error occurred: ({StatusCode}) {Title} - {Detail}",
            problem!.Status,
            problem!.Title,
            problem.Detail);
    }
}
