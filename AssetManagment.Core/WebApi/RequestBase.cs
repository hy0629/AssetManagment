using System.Text.Json.Serialization;

namespace AssetManagment.Core.WebApi
{
    public class RequestBase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Title { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }
    }
}
