namespace RichillCapital.TraderStudio.Web.Services.Contracts.AuditLogs;

public sealed record AuditLogResponse
{
    public required string Id { get; init; }
}