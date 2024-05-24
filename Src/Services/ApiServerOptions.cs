using FluentValidation;

namespace RichillCapital.TraderStudio.Web.Services;

internal sealed record ApiServerOptions
{
    internal const string SectionKey = "ApiServer";

    public required string BaseAddress { get; init; }
}

internal sealed class ApiServerOptionsValidator :
    AbstractValidator<ApiServerOptions>
{
    public ApiServerOptionsValidator()
    {
        RuleFor(x => x.BaseAddress)
            .NotEmpty();
    }
}