namespace RichillCapital.TraderStudio.Web.Contracts;

public sealed record SignalModel
{
    public required DateTimeOffset Time { get; init; }

    public required string TradeType { get; init; }

    public required string Symbol { get; init; }

    public required decimal Quantity { get; init; }

    public required decimal Price { get; init; }
}