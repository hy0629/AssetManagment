using System.Text.Json.Serialization;


namespace AssetManagment.Core.WebApi
{
    public class RequestWithRegion:RequestBase
    {
        [JsonPropertyName("region")]
        public int RegionId { get; set; }
    }
}
