using RichillCapital.TraderStudio.Web.Services.Contracts.Accounts;
using RichillCapital.TraderStudio.Web.Services.Contracts.Executions;
using RichillCapital.TraderStudio.Web.Services.Contracts.Instruments;
using RichillCapital.TraderStudio.Web.Services.Contracts.Orders;
using RichillCapital.TraderStudio.Web.Services.Contracts.Users;
using RichillCapital.TraderStudio.Web.Src.Services.Contracts;

namespace RichillCapital.TraderStudio.Web.Services;

internal interface IApiService
{
    Task<PagedResponse<UserResponse>> ListUsersAsync(CancellationToken cancellationToken = default);
    Task<UserDetailsResponse> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default);

    Task<PagedResponse<InstrumentResponse>> ListInstrumentsAsync(CancellationToken cancellationToken = default);

    Task<PagedResponse<AccountResponse>> ListAccountsAsync(CancellationToken cancellationToken = default);
    Task<AccountDetailsResponse> GetAccountByIdAsync(string accountId, CancellationToken cancellationToken = default);

    Task<PagedResponse<OrderResponse>> ListOrdersAsync(CancellationToken cancellationToken = default);
    Task<string> CreateOrderAsync(CreateOrderRequest request, CancellationToken cancellationToken = default);

    Task<PagedResponse<ExecutionResponse>> ListExecutionsAsync(CancellationToken cancellationToken = default);
}
