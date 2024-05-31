namespace RichillCapital.TraderStudio.Web.Services.Contracts.Orders;

public sealed class CreateOrderRequest
{
    public required string AccountId { get; init; }

    public required string TradeType { get; init; }

    public required string Type { get; init; }

    public required string Symbol { get; init; }

    public required decimal Quantity { get; init; }

    public required decimal Price { get; init; }

    public required string TimeInForce { get; init; }
}

public sealed record CreateOrderResponse
{
    public required string Id { get; init; }
}