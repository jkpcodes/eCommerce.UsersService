using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(50).WithMessage("Password must not exceed 50 characters.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one digit");

        RuleFor(x => x.PersonName)
            .NotEmpty().WithMessage("Person name is required.")
            .MinimumLength(1).WithMessage("Person name must be at least 1 characters long.")
            .MaximumLength(50).WithMessage("Person name must not exceed 50 characters.");

        RuleFor(x => x.Gender)
            .NotNull().WithMessage("Gender is required.")
            .IsInEnum().WithMessage("Gender must be a valid value.");
    }
}
