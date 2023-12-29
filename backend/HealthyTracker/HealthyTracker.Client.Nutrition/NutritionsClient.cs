using HealthyTracker.Client.Nutrition.Extensions;
using HealthyTracker.Client.Nutrition.Models.Requests;
using HealthyTracker.Client.Nutrition.Models.Responses;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace HealthyTracker.Client.Nutrition;
public class NutritionsClient : INutritionsClient
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<NutritionsClient> _logger;

    // Move this to config or secrets
    private string AppId = "c79812f0";
    private string AppKey = "a82e4b76af837b479419027da99c3c10";

    public NutritionsClient(
        IHttpClientFactory clientFactory,
        ILogger<NutritionsClient> logger)
    {
        _clientFactory = clientFactory;
        _logger = logger;
    }

    public async Task<GetNutritionsByNameResponse?> GetNutritionsByNameAsync(GetNutritionsByNameRequest request)
    {
        try
        {
            var client = _clientFactory.CreateRestClient("NutritionsClient");

            var restRequest = new RestRequest("https://trackapi.nutritionix.com/v2/natural/nutrients")
                .AddHeader("x-app-id", AppId)
                .AddHeader("x-app-key", AppKey)
                .AddBody(request);

            var result = await client.PostAsync<GetNutritionsByNameResponse>(restRequest);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Nutrition client");
            return null;
        }
    }
}
