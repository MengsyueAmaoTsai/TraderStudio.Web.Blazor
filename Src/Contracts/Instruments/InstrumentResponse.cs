namespace RichillCapital.TraderStudio.Web.Contracts.Instruments;

public record InstrumentResponse
{
    public required string Symbol { get; init; }

    public required string Description { get; init; }
    
    public required string Exchange { get; init; }

    public required string Type { get; init; }
}
