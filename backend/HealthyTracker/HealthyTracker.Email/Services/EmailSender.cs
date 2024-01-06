using FluentEmail.Core;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.Common.Models.Utility;
using HealthyTracker.Email.Models.Base;
using HealthyTracker.Email.Services.Interfaces;
using LanguageExt;
using Microsoft.Extensions.Logging;
using EmailMessageBase = HealthyTracker.Email.Models.Base.EmailMessageBase;

namespace HealthyTracker.Email.Services;

public class EmailSender : IEmailSender
{
    private readonly IFluentEmail _fluentEmail;
    private readonly ILogger<EmailSender> _logger;
    private readonly EmailConfig _config;

    public EmailSender(IFluentEmail email, EmailConfig config, ILogger<EmailSender> logger)
    {
        _fluentEmail = email;
        _config = config;
        _logger = logger;
    }
    
    public async Task<Option<ErrorModel>> SendEmailAsync<T>(string to, T message)
        where T : EmailMessageBase
    {
        var path = $@"{_config.TemplatesPath}\{message.TemplateName}.cshtml";
        var response = await _fluentEmail
            .To(to)
            .Subject(message.Subject)
            .UsingTemplateFromFile(path, message)
            .SendAsync();

        if (!response.Successful)
        {
            _logger.LogError("Errors while sending email: {0}", string.Join("\n", response.ErrorMessages));
            return new ErrorModel("Unable to send an email. Please try again later");
        }
        
        return Option<ErrorModel>.None;
    }
}