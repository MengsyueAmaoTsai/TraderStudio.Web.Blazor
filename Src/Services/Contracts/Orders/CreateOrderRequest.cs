namespace RichillCapital.TraderStudio.Web.Services.Contracts.Orders;

public sealed class CreateOrderRequest
{
    public string AccountId { get; set; } = string.Empty;

    public string TradeType { get; set; } = string.Empty;

    public string OrderType { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public string TimeInForce { get; set; } = string.Empty;
}
