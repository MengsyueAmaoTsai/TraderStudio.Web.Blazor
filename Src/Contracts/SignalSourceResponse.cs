namespace RichillCapital.TraderStudio.Web.Contracts;

public record SignalSourceResponse
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}

public record SignalSourceDetailsResponse : SignalSourceResponse
{
    public required IEnumerable<SignalResponse> Signals { get; init; }
}


public sealed record SignalResponse
{
    public required string Id { get; init; }
    public required DateTimeOffset Time { get; init; }
    public required string SourceId { get; init; }
    public required string TradeType { get; init; }
    public required string Symbol { get; init; }
    public required decimal Quantity { get; init; }
    public required decimal Price { get; init; }
}