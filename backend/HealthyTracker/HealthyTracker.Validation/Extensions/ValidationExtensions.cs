using FluentValidation;
using FluentValidation.Results;
using HealthyTracker.Common.Models.Configs.Abstract;
using HealthyTracker.Common.Models.DTOs.Error;
using HealthyTracker.Validation.Utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HealthyTracker.Validation.Extensions;

public static class ValidationExtensions
{
    public static ErrorDto ToErrorDTO(this ValidationResult result)
    {
        return new ValidationFailedErrorDTO(result.ToDictionary());
    }

    public static async Task ValidateConfigsAsync(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var configsWithValidators = services.GetServices<IConfigValidator>()
            .ToDictionary(
                v => (ConfigBase)services.GetRequiredService(v.GetType().BaseType!.GenericTypeArguments.First()),
                v => v);

        foreach (var (config, validator) in configsWithValidators)
        {
            var result = await validator.ValidateConfigAsync(config);
            if (!result.IsValid)
                throw new Exception($"Config {config.GetType()} is invalid: {string.Join(" ", result.Errors)}");
        }
    }

    public static IServiceCollection AddValidatorServiceFromAssemblyContaining<T>(this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        services.AddValidatorsFromAssemblyContaining<T>();

        foreach (var scanResult in AssemblyScanner.FindValidatorsInAssembly(typeof(T).Assembly))
        {
            if (scanResult.IsConfigValidator())
            {
                services.AddScanResultAsConfigValidator(scanResult, lifetime);
                continue;
            }

            services.AddScanResultAsNonGeneric(scanResult, lifetime);
        }

        services.AddScoped<IValidatorService, ValidatorService>();
        return services;
    }

    private static IServiceCollection AddScanResultAsNonGeneric(this IServiceCollection services,
        AssemblyScanner.AssemblyScanResult scanResult, ServiceLifetime lifetime)
    {
        services.Add(new ServiceDescriptor(
            serviceType: typeof(IValidator),
            implementationType: scanResult.ValidatorType,
            lifetime: lifetime));

        return services;
    }

    private static IServiceCollection AddScanResultAsConfigValidator(this IServiceCollection services,
        AssemblyScanner.AssemblyScanResult scanResult, ServiceLifetime lifetime)
    {
        services.Add(new ServiceDescriptor(
            serviceType: typeof(IConfigValidator),
            implementationType: scanResult.ValidatorType,
            lifetime: lifetime));

        return services;
    }

    private static bool IsConfigValidator(this AssemblyScanner.AssemblyScanResult scanResult)
    {
        return scanResult.InterfaceType.IsGenericType &&
               scanResult.InterfaceType.GenericTypeArguments.First().IsConfig();
    }

    private static bool IsConfig(this Type type)
    {
        var currentType = type;
        while (currentType.BaseType != null)
        {
            if (currentType == typeof(ConfigBase))
                return true;

            currentType = currentType.BaseType;
        }

        return false;
    }
}