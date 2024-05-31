namespace RichillCapital.TraderStudio.Web.Services.Contracts.Users;

public record UserResponse
{
    public required string Id { get; init; }

    public required string Email { get; init; }

    public required string Name { get; init; }
}
