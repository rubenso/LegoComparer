using System.Text.Json.Serialization;

namespace LegoComparer.Model.LegoApi
{


    public class Set
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("setNumber")]
        public string SetNumber { get; set; }

        [JsonPropertyName("totalPieces")]
        public long TotalPieces { get; set; }

        [JsonPropertyName("pieces")]
        public IEnumerable<SetPiece> Pieces { get; set; }
    }
}


