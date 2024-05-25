namespace RichillCapital.TraderStudio.Web.Contracts.AuditLogs;

public sealed record AuditLogResponse
{
    public required string Id { get; init; }
    public required DateTimeOffset Time { get; init; }
}