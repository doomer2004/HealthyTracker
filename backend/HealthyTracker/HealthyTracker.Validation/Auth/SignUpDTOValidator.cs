using FluentValidation;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Validation.Extensions;

namespace HealthyTracker.Validation.Auth;

public class SignUpDTOValidator : AbstractValidator<SignUpDTO>
{
    public SignUpDTOValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(32);
        
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(32);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .Password();
    }
}