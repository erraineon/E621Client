using Newtonsoft.Json;

namespace E621
{
    public class E621SearchOptions
    {
        public int Limit { get; set; }

        [JsonIgnore] public long? BeforeId { get; set; }

        [JsonIgnore] public long? AfterId { get; set; }

        public int Page { get; set; }
        public string Tags { get; set; }
    }
}