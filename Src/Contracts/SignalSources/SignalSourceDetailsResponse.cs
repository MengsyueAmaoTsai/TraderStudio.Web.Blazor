namespace RichillCapital.TraderStudio.Web.Contracts.SignalSources;

public record SignalSourceDetailsResponse : SignalSourceResponse
{
    public required IEnumerable<SignalResponse> Signals { get; init; }
}
