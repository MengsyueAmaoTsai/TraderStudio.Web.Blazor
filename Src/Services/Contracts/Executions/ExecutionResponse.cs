namespace RichillCapital.TraderStudio.Web.Services.Contracts.Executions;

public sealed class ExecutionResponse
{
    public required string Id { get; init; }

    public required string AccountId { get; init; }

    public required DateTimeOffset Time { get; init; }

    public required string TradeType { get; init; }

    public required string Symbol { get; init; }

    public required decimal Quantity { get; init; }

    public required decimal Price { get; init; }

    public required decimal Commission { get; init; }

    public required decimal Tax { get; init; }
}