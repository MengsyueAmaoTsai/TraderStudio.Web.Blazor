using RichillCapital.TraderStudio.Web.Services.Contracts.Accounts;
using RichillCapital.TraderStudio.Web.Services.Contracts.Users;
using RichillCapital.TraderStudio.Web.Src.Services.Contracts;

namespace RichillCapital.TraderStudio.Web.Services;

internal interface IApiService
{
    Task<PagedResponse<UserResponse>> ListUsersAsync(CancellationToken cancellationToken = default);

    Task<PagedResponse<AccountResponse>> ListAccountsAsync(CancellationToken cancellationToken = default);
    Task<AccountDetailsResponse> GetAccountByIdAsync(string accountId, CancellationToken cancellationToken = default);
}
