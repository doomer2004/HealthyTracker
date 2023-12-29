using System.Text.Json.Serialization;

namespace HealthyTracker.Client.Nutrition.Models.Requests;
public class GetNutritionsByNameRequest : IRequest
{
    [JsonPropertyName("query")]
    public string Query { get; set; }
}
