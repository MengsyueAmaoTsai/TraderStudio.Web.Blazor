namespace RichillCapital.TraderStudio.Web.Contracts;

public sealed record TradingBotModel
{
    public required string Id { get; init; }

    public required string Name { get; init; }

    public required string Platform { get; init; }
}