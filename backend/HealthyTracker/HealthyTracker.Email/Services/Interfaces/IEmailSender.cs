﻿using HealthyTracker.Common.Models.Utility;
using HealthyTracker.Email.Models.Base;
using LanguageExt;

namespace HealthyTracker.Email.Services.Interfaces;

public interface IEmailSender
{
    Task<Option<ErrorModel>> SendEmailAsync<T>(string to, T message)
        where T : EmailMessageBase;
}