using FluentValidation;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Validation.Utility;

namespace HealthyTracker.Validation.Config;

public class EmailConfigValidator : ConfigValidatorBase<EmailConfig>
{
    public EmailConfigValidator()
    {
        RuleFor(x => x.SmtpServer)
            .NotEmpty();

        RuleFor(x => x.SmtpPort)
            .NotEmpty();

        RuleFor(x => x.DefaultEmail)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();

        RuleFor(x => x.TemplatesPath)
            .NotEmpty()
            .Must(Directory.Exists);
    }
}