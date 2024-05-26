using FluentValidation;

namespace RichillCapital.TraderStudio.Web.Services;

internal sealed class ApiServerOptionsValidator :
    AbstractValidator<ApiServerOptions>
{
    public ApiServerOptionsValidator()
    {
        RuleFor(x => x.BaseAddress)
            .NotEmpty();
    }
}