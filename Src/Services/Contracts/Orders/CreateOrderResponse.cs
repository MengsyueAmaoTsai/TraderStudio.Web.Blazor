namespace RichillCapital.TraderStudio.Web.Services.Contracts.Orders;

public sealed record CreateOrderResponse
{
    public required string Id { get; init; }
}