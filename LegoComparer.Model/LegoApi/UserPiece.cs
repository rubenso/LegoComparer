using System.Collections;
using System.Text.Json.Serialization;

namespace LegoComparer.Model.LegoApi
{
    public  class UserPiece
    {
        [JsonPropertyName("pieceId")]
        public string PieceId { get; set; }

        [JsonPropertyName("variants")]
        public IList<Variant> Variants { get; set; }


    }
}
