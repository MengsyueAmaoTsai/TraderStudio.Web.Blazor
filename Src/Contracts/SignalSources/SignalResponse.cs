namespace RichillCapital.TraderStudio.Web.Contracts.SignalSources;

public sealed record SignalResponse
{
    public required string Id { get; init; }
    public required DateTimeOffset Time { get; init; }
    public required string SourceId { get; init; }
    public required string TradeType { get; init; }
    public required string Symbol { get; init; }
    public required decimal Quantity { get; init; }
    public required decimal Price { get; init; }
    public required decimal Latency { get; init; }
}