using FluentValidation;

namespace RichillCapital.Infrastructure.Identity;

internal sealed class IdentityOptionsValidator :
    AbstractValidator<IdentityOptions>
{
    public IdentityOptionsValidator()
    {
    }
}