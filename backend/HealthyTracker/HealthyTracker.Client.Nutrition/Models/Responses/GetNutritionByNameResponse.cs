using System.Text.Json.Serialization;

namespace HealthyTracker.Client.Nutrition.Models.Responses;
public class GetNutritionByNameResponse
{
    public List<Food> Foods { get; set; }
}
public class FullNutrient
{
    [JsonPropertyName("attr_id")]
    public int AttrId { get; set; }

    [JsonPropertyName("value")]
    public double Value { get; set; }
}

public class Tags
{
    [JsonPropertyName("item")]
    public string Item { get; set; }

    [JsonPropertyName("measure")]
    public string Measure { get; set; }

    [JsonPropertyName("quantity")]
    public string Quantity { get; set; }

    [JsonPropertyName("food_group")]
    public int FoodGroup { get; set; }

    [JsonPropertyName("tag_id")]
    public int TagId { get; set; }
}

public class AltMeasure
{
    [JsonPropertyName("serving_weight")]
    public double ServingWeight { get; set; }

    [JsonPropertyName("measure")]
    public string Measure { get; set; }

    [JsonPropertyName("seq")]
    public int? Seq { get; set; }

    [JsonPropertyName("qty")]
    public int Qty { get; set; }
}

public class Metadata
{
    [JsonPropertyName("is_raw_food")]
    public bool IsRawFood { get; set; }
}

public class Photo
{
    [JsonPropertyName("thumb")]
    public string Thumb { get; set; }

    [JsonPropertyName("highres")]
    public string Highres { get; set; }

    [JsonPropertyName("is_user_uploaded")]
    public bool IsUserUploaded { get; set; }
}

public class Food
{
    [JsonPropertyName("food_name")]
    public string FoodName { get; set; }

    [JsonPropertyName("brand_name")]
    public object BrandName { get; set; }

    [JsonPropertyName("serving_qty")]
    public int ServingQty { get; set; }

    [JsonPropertyName("serving_unit")]
    public string ServingUnit { get; set; }

    [JsonPropertyName("serving_weight_grams")]
    public double ServingWeightGrams { get; set; }

    [JsonPropertyName("nf_calories")]
    public double Calories { get; set; }

    [JsonPropertyName("nf_total_fat")]
    public double TotalFat { get; set; }

    [JsonPropertyName("nf_saturated_fat")]
    public double SaturatedFat { get; set; }

    [JsonPropertyName("nf_cholesterol")]
    public int Cholesterol { get; set; }

    [JsonPropertyName("nf_sodium")]
    public double Sodium { get; set; }

    [JsonPropertyName("nf_total_carbohydrate")]
    public double TotalCarbohydrate { get; set; }

    [JsonPropertyName("nf_dietary_fiber")]
    public double DietaryFiber { get; set; }

    [JsonPropertyName("nf_sugars")]
    public double Sugars { get; set; }

    [JsonPropertyName("nf_protein")]
    public double Protein { get; set; }

    [JsonPropertyName("nf_potassium")]
    public double Potassium { get; set; }

    [JsonPropertyName("nf_p")]
    public double P { get; set; }

    [JsonPropertyName("full_nutrients")]
    public List<FullNutrient> FullNutrients { get; set; }

    [JsonPropertyName("nix_brand_name")]
    public object NixBrandName { get; set; }

    [JsonPropertyName("nix_brand_id")]
    public object NixBrandId { get; set; }

    [JsonPropertyName("nix_item_name")]
    public object NixItemName { get; set; }

    [JsonPropertyName("nix_item_id")]
    public object NixItemId { get; set; }

    [JsonPropertyName("upc")]
    public object UPC { get; set; }

    [JsonPropertyName("consumed_at")]
    public DateTime ConsumedAt { get; set; }

    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; }

    [JsonPropertyName("source")]
    public int Source { get; set; }

    [JsonPropertyName("ndb_no")]
    public int NdbNo { get; set; }

    [JsonPropertyName("tags")]
    public Tags Tags { get; set; }

    [JsonPropertyName("alt_measures")]
    public List<AltMeasure> AltMeasures { get; set; }

    [JsonPropertyName("lat")]
    public object Lat { get; set; }

    [JsonPropertyName("lng")]
    public object Lng { get; set; }

    [JsonPropertyName("meal_type")]
    public int MealType { get; set; }

    [JsonPropertyName("photo")]
    public Photo Photo { get; set; }

    [JsonPropertyName("sub_recipe")]
    public object SubRecipe { get; set; }

    [JsonPropertyName("class_code")]
    public object ClassCode { get; set; }

    [JsonPropertyName("brick_code")]
    public object BrickCode { get; set; }

    [JsonPropertyName("tag_id")]
    public object TagId { get; set; }
}