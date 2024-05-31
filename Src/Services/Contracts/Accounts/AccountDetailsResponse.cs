using RichillCapital.TraderStudio.Web.Services.Contracts.Orders;

namespace RichillCapital.TraderStudio.Web.Services.Contracts.Accounts;

public sealed record AccountDetailsResponse : AccountResponse
{
    public required IEnumerable<OrderResponse> Orders { get; init; }
}