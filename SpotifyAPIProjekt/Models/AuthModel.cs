using System.Text.Json.Serialization;

namespace SpotifyAPIProjekt.Models
{
    public class AuthModel
    {
        //[JsonPropertyName("access_token")] doesn't work!
        public string access_token { get; set; }

        //[JsonPropertyName("token_type")] doesn't work!
        public string token_type { get; set; }

        //[JsonPropertyName("expires_in")] doesn't work!
        public int expires_in { get; set; }
    }
}
