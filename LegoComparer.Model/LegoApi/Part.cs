using System.Text.Json.Serialization;

namespace LegoComparer.Model.LegoApi
{
    public  class Part
    {
        [JsonPropertyName("designID")]
        public string DesignId { get; set; }

        [JsonPropertyName("material")]
        public long Colour { get; set; }

        [JsonPropertyName("partType")]
        public string PartType { get; set; }

      


    }
}
