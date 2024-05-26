using FluentValidation;

namespace RichillCapital.Identity;

internal sealed class IdentityOptionsValidator :
    AbstractValidator<IdentityOptions>
{
    public IdentityOptionsValidator()
    {
    }
}