using System.Text.Json.Serialization;

namespace AssetManagment.Core.WebApi
{
    public class AssetInfoRequest
    {
        [JsonPropertyName("category")]
        public int CategoryId { get; set; }

        [JsonPropertyName("asset_name")]
        public string AssetName { get; set; }

        [JsonPropertyName("asset_spec")]
        public string AssetSpec { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("asset_number")]
        public string AssetNumber { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("asset_state")]
        public int AssetState { get; set; }

        [JsonPropertyName("region")]
        public int Region { get; set; }

        [JsonPropertyName("asset_storage")]
        public int AssetStorage { get; set; }

        [JsonPropertyName("department")]
        public int Department { get; set; }

        [JsonPropertyName("used_person")]
        public int UsedPerson { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("service_life")]
        public string ServiceLife { get; set; }

        [JsonPropertyName("used_time")]
        public string UsedTime { get; set; }

        [JsonPropertyName("record_time")]
        public string RecordTime { get; set; }

        [JsonPropertyName("registrar")]
        public int Registrar { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
