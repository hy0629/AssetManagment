using System.Text.Json.Serialization;

namespace AssetManagment.Core.WebApi
{
    public class BaseData<T>
    {
        [JsonPropertyName("value")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public T Value { get; set; }
    }
}
