using RichillCapital.TraderStudio.Web.Services.Contracts.Executions;
using RichillCapital.TraderStudio.Web.Services.Contracts.Orders;
using RichillCapital.TraderStudio.Web.Services.Contracts.Positions;

namespace RichillCapital.TraderStudio.Web.Services.Contracts.Accounts;


public sealed record AccountDetailsResponse :
    AccountResponse
{
    public required IEnumerable<OrderResponse> Orders { get; init; }

    public required IEnumerable<ExecutionResponse> Executions { get; init; }

    public required IEnumerable<PositionResponse> Positions { get; init; }
}
