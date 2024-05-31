namespace RichillCapital.TraderStudio.Web.Services.Contracts.Positions;

public sealed class PositionResponse
{
    public required string Id { get; set; }

    public required string AccountId { get; set; }

    public required string Side { get; set; }

    public required string Symbol { get; set; }

    public required decimal Quantity { get; set; }

    public required decimal Price { get; set; }
}
