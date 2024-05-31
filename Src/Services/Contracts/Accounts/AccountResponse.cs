namespace RichillCapital.TraderStudio.Web.Services.Contracts.Accounts;

public record AccountResponse
{
    public required string Id { get; init; }

    public required string Name { get; init; }
}
