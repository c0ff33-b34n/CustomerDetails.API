using System.Text.Json.Serialization;

namespace CustomerDetailsApi.Models
{
    public class CustomerToReturnDto
    {
        [JsonPropertyNameAttribute("id")]
        public int Id { get; set; }
        [JsonPropertyNameAttribute("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyNameAttribute("lasName")]
        public string LastName { get; set; }
        [JsonPropertyNameAttribute("businessName")]
        public string BusinessName { get; set; }
        [JsonPropertyNameAttribute("buildingName")]
        public string BuildingName { get; set; }
        [JsonPropertyNameAttribute("numberAndStreet")]
        public string NumberAndStreet { get; set; }
        [JsonPropertyNameAttribute("localityName")]
        public string LocalityName { get; set; }
        [JsonPropertyNameAttribute("townOrCity")]
        public string TownOrCity { get; set; }
        [JsonPropertyNameAttribute("county")]
        public string County { get; set; }
        [JsonPropertyNameAttribute("postcode")]
        public string PostCode { get; set; }
    }
}