using Newtonsoft.Json;

namespace EnterpriseApp.Data
{
   public class Posts

    {

        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int UserID { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

    }
}
