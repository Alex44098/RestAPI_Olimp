using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace RestAPI.Controllers.JsonPropertis
{    
    public class AccountJson
    {
        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("email")]
        public string Email { get; set; }

        [System.Text.Json.Serialization.JsonRequired]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}