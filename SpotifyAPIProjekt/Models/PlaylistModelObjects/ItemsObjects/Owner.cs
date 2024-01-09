using Newtonsoft.Json;
using SpotifyAPIProjekt.Models.ProfileModelObjects;
using System.Text.Json.Serialization;

namespace SpotifyAPIProjekt.Models.PlaylistModelObjects.ItemsObjects
{
    public class Owner
    {
        [JsonProperty("external_urls")]
        public ExternalUrls? ExternalUrls { get; set; }

        [JsonProperty("followers")]
        public Followers? Followers { get; set; }

        [JsonProperty("href")]
        public string? Href { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("uri")]
        public string? Uri { get; set; }

        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }
    }
}
