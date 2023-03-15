using Newtonsoft.Json;

namespace RestAPI.Controllers.JsonPropertis
{
    public class AnimalVisitedLocationJson
    {
        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("visitedLocationId")]
        public long VisitedLocationPointId { get; set; }

        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("locationPointId")]
        public long LocationPointId { get; set; }
    }
}
