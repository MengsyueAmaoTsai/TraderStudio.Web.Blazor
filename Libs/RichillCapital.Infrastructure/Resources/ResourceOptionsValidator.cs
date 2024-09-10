using FluentValidation;

namespace RichillCapital.Infrastructure.Resources;

internal sealed class ResourceOptionsValidator : AbstractValidator<ResourceOptions>
{
    public ResourceOptionsValidator()
    {
        RuleFor(options => options.BaseAddress)
            .NotEmpty()
            .WithMessage("Base address is required.");
    }
}