using System.Text.Json.Serialization;

namespace AssetManagment.Core.WebApi
{
    public class ResultWithRegion:ResultBase
    {
        [JsonPropertyName("region")]
        public BaseData<string> Region { get; set; }
    }
}
