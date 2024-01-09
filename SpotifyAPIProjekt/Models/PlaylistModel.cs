using Newtonsoft.Json;

namespace SpotifyAPIProjekt.Models
{
    public class PlaylistModel
    {
        [JsonProperty("href")]
        public string? Href { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("next")]
        public string? Next { get; set; }

        [JsonProperty("offset")]
        public int? Offset { get; set; }

        [JsonProperty("previous")]
        public string? Previous { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }
}
