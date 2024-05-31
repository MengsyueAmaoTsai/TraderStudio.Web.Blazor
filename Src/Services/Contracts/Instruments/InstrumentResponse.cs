namespace RichillCapital.TraderStudio.Web.Services.Contracts.Instruments;

public class InstrumentResponse
{
    public required string Symbol { get; set; }

    public required string Description { get; set; }

    public required string Exchange { get; set; }

    public required string Type { get; set; }
}