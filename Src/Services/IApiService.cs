using RichillCapital.TraderStudio.Web.Services.Contracts.Users;
using RichillCapital.TraderStudio.Web.Src.Services.Contracts;

namespace RichillCapital.TraderStudio.Web.Services;

internal interface IApiService
{
    Task<PagedResponse<UserResponse>> ListUsersAsync(CancellationToken cancellationToken = default);
}
