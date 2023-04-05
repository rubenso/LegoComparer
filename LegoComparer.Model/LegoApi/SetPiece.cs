using System.Collections;
using System.Text.Json.Serialization;

namespace LegoComparer.Model.LegoApi
{
    public  class SetPiece
    {
        [JsonPropertyName("quantity")]
        public long Quantity { get; set; }

        [JsonPropertyName("part")]
        public Part Part { get; set; }


    }
}
