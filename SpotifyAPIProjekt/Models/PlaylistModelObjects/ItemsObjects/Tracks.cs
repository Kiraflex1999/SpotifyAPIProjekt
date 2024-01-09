using Newtonsoft.Json;

namespace SpotifyAPIProjekt.Models.PlaylistModelObjects.ItemsObjects
{
    public class Tracks
    {
        [JsonProperty("href")]
        public string? Href { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }
}
