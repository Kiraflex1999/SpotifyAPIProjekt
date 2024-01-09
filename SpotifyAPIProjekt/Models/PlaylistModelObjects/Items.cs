using Newtonsoft.Json;
using SpotifyAPIProjekt.Models.PlaylistModelObjects.ItemsObjects;
using SpotifyAPIProjekt.Models.ProfileModelObjects;

namespace SpotifyAPIProjekt.Models.PlaylistModelObjects
{
    public class Items
    {
        [JsonProperty("collaborative")]
        public bool? Collaborative { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("external_urls")]
        public ExternalUrls? ExternalUrls { get; set; }

        [JsonProperty("href")]
        public string? Href { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("images")]
        public Images[]? Images { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("owner")]
        public Owner? Owner { get; set; }

        [JsonProperty("public")]
        public bool? Public { get; set; }

        [JsonProperty("snapshot_id")]
        public string? SnapshotId { get; set; }

        [JsonProperty("tracks")]
        public Tracks? Tracks { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("uri")]
        public string? Uri { get; set; }
    }
}
