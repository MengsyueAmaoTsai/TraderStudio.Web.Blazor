using Microsoft.AspNetCore.Http;

using RichillCapital.Domain;
using RichillCapital.UseCases.Common;

namespace RichillCapital.Identity;

internal sealed class CurrentWebUser(
    IHttpContextAccessor _httpContextAccessor) :
    ICurrentUser
{
    public bool IsAuthenticated =>
        _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ??
            throw new ApplicationException("User context is unavailable");

    public UserId Id => _httpContextAccessor.HttpContext!.User.GetId();
}
