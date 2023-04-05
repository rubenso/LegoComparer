using System.Text.Json.Serialization;

namespace LegoComparer.Model.LegoApi
{
    public partial class Colours
    {
        [JsonPropertyName("colours")]
        public Colour[] Colors { get; set; }

        [JsonPropertyName("disclaimer")]
        public string? Disclaimer { get; set; }
    }
}
