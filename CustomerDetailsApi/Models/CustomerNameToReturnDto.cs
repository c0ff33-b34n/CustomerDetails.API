using System.Text.Json.Serialization;

namespace CustomerDetailsApi.Models
{
    public class CustomerNameToReturnDto
    {
        [JsonPropertyNameAttribute("id")]
        public int Id { get; set; }
        [JsonPropertyNameAttribute("firstname")]
        public string FirstName { get; set; }
        [JsonPropertyNameAttribute("lastname")]
        public string LastName { get; set; }
    }
}