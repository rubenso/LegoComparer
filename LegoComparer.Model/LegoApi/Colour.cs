using System.Text.Json.Serialization;

namespace LegoComparer.Model.LegoApi
{
    public partial class Colour
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public long Code { get; set; }
    }
}
