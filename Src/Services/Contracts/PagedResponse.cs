namespace RichillCapital.TraderStudio.Web.Src.Services.Contracts;

public sealed record PagedResponse<TResponse>
{
    public required IReadOnlyCollection<TResponse> Items { get; init; }
}
