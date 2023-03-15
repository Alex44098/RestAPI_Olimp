using Newtonsoft.Json;

namespace RestAPI.Controllers.JsonPropertis
{
    public class AnimalTypeJson
    {
        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
