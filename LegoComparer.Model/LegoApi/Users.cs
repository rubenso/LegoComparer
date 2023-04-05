using System.Text.Json.Serialization;

namespace LegoComparer.Model.LegoApi
{
    public class Users
    {
        [JsonPropertyName("Users")]
        public IList<User> Items { get; set; }
    }
}
