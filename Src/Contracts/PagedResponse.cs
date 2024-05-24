namespace RichillCapital.TraderStudio.Web.Contracts;

public sealed record PagedResponse<TResponse>
{
    public required IReadOnlyCollection<TResponse> Items { get; init; }
}
