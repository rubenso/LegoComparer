using System.Text.Json.Serialization;

namespace LegoComparer.Model.LegoApi
{
    public  class Variant
    {
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("count")]
        public long Count { get; set; }

        public long ColourNmr => long.Parse(Color);
    }
}
