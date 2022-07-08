using System.Text.Json.Serialization;

namespace AssetManagment.Core.WebApi
{
    public class AssetInfoResult
    {
        [JsonPropertyName("asset_number")]
        public string AssetNumber { get; set; }

        [JsonPropertyName("asset_source")]
        public string AssetSource { get; set; }

        [JsonPropertyName("asset_state")]
        public string AssetState { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("storage")]
        public string Storage { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("member")]
        public string Member { get; set; }

        [JsonPropertyName("asset_category")]
        public string Category { get; set; }

        [JsonPropertyName("asset_name")]
        public string AssetName { get; set; }

        [JsonPropertyName("asset_spec")]
        public string AssetSpec { get; set; }

        [JsonPropertyName("asset_unit")]
        public string AssetUnit { get; set; }

        [JsonPropertyName("price")]
        public string AssetPrice { get; set; }

        [JsonPropertyName("registrar")]
        public string Registrar { get; set; }

        [JsonPropertyName("record_time")]
        public string RecordTime { get; set; }

        [JsonPropertyName("used_time")]
        public string UsedTime { get; set; }

        [JsonPropertyName("service_life")]
        public string ServiceLife { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }
    }
}
