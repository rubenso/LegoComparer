


using System.Text.Json.Serialization;

namespace LegoComparer.Model.LegoApi
{
    public class Sets
    {
        [JsonPropertyName("Sets")]
        public Set[] Items { get; set; }
    }


}


