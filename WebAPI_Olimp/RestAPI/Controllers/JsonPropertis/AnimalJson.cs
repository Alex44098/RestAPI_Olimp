using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RestAPI.Controllers.JsonPropertis
{
    public class AnimalJson
    {
        [JsonProperty("animalTypes")]
        public long[] AnimalTypes { get; set; }

        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("weight")]
        public float Weight { get; set; }

        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("lenght")]
        public float Lenght { get; set; }

        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("height")]
        public float Height { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("chipperId")]
        public int ChipperId { get; set; }

        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("chippingLocationId")]
        public long ChippingLocationId { get; set; }
    }
}
