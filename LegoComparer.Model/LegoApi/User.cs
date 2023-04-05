using System.Text.Json.Serialization;

namespace LegoComparer.Model.LegoApi
{
    public partial class User
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("brickCount")]
        public long BrickCount { get; set; }

        [JsonPropertyName("collection")]
        public IEnumerable<UserPiece> UserPieces { get; set; }
    }
}
