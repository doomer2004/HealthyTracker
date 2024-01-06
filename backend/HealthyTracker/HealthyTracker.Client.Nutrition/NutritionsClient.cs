using HealthyTracker.Client.Nutrition.Extensions;
using HealthyTracker.Client.Nutrition.Models.Requests;
using HealthyTracker.Client.Nutrition.Models.Responses;
using HealthyTracker.Common.Models.Configs;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace HealthyTracker.Client.Nutrition;
public class NutritionsClient : INutritionsClient
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<NutritionsClient> _logger;
    private readonly NutritionsConfig _nutritionsConfig;
    public NutritionsClient(
        IHttpClientFactory clientFactory,
        ILogger<NutritionsClient> logger, NutritionsConfig nutritionsConfig)
    {
        _clientFactory = clientFactory;
        _logger = logger;
        _nutritionsConfig = nutritionsConfig;
    }
    
    

    public async Task<GetNutritionByNameResponse?> GetNutritionsByNameAsync(GetNutritionByNameRequest request)
    {
        try
        {
            var client = _clientFactory.CreateRestClient("NutritionsClient");

            var restRequest = new RestRequest("https://trackapi.nutritionix.com/v2/natural/nutrients")
                .AddHeader("x-app-id", _nutritionsConfig.AppId)
                .AddHeader("x-app-key", _nutritionsConfig.AppKey)
                .AddBody(request);

            var result = await client.PostAsync<GetNutritionByNameResponse>(restRequest);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Nutrition client");
            return null;
        }
    }
}
