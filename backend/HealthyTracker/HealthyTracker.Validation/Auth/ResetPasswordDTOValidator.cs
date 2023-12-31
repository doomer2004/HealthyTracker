﻿using FluentValidation;
using HealthyTracker.Common.Models.DTOs.Auth;
using HealthyTracker.Validation.Extensions;

namespace HealthyTracker.Validation.Auth;

public class ResetPasswordDTOValidator : AbstractValidator<ResetPasswordDTO>
{
    public ResetPasswordDTOValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Token)
            .NotEmpty();

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .Password();
    }
}