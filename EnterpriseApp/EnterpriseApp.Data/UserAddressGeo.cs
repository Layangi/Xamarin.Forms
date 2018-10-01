using Newtonsoft.Json;

namespace EnterpriseApp.Data
{
    public class UserAddressGeo
    {
        [JsonProperty(PropertyName = "lat")]
        public double? Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public double? Longitude { get; set; }
    }
}
