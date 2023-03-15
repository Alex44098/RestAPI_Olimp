using Newtonsoft.Json;

namespace RestAPI.Controllers.JsonPropertis
{
    public class LocationPointJson
    {
        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("latitude")]
       public double Latitude { get; set; }

        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("longitude")]
       public double Longitude { get; set; }
    }
}
